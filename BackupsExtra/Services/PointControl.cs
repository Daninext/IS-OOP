using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using Backups.Services;

namespace BackupsExtra.Services
{
    public class PointControl : IPointControl
    {
        private IClearStrategy _clearStrategy;
        private IClearLimit _clearLimit;
        private ILogging _logger;

        private List<BackupJob> _jobs = new List<BackupJob>();

        private string _configPath = Directory.GetCurrentDirectory() + "\\config.zip";

        public PointControl()
        {
            ChangeLoggingMethod(new ConsoleLogging());
            LoadConfig();
            ChangeClearLimit(new CountLimit(1));
            ChangeClearStrategy(new DeleteStrategy());
        }

        ~PointControl()
        {
            SaveConfig();
        }

        public void RecoverData(RestorePoint point, string location = null)
        {
            point.Recover(location);
            _logger.SaveLog("Files has been recovered. Point: " + point.ToString());
        }

        public void ClearOldData()
        {
            foreach (BackupJob job in _jobs)
            {
                _logger.SaveLog("Job before clear: " + job.ToString());
                IReadOnlyList<RestorePoint> mustToClearPoints = _clearLimit.ChooseToClear(job);
                _clearStrategy.Clear(mustToClearPoints, job);
                _logger.SaveLog("Job after clear: " + job.ToString());
            }
        }

        public void AddBackupJob(BackupJob job)
        {
            if (_jobs.FirstOrDefault(j => j == job) != null)
                throw new Exception("There is same Backup Job");

            _jobs.Add(job);
            job.Notify += _logger.SaveLog;
            _logger.SaveLog("Job has been added. " + job.ToString());
        }

        public void RemoveBackupJob(BackupJob job)
        {
            if (_jobs.FirstOrDefault(j => j == job) == null)
                throw new Exception("There isn`t same Backup Job");

            _jobs.Remove(job);
            job.Notify -= _logger.SaveLog;
            _logger.SaveLog("Job has been removed. " + job.ToString());
        }

        public void ChangeClearStrategy(IClearStrategy newStrategy)
        {
            _clearStrategy = newStrategy;
            _logger.SaveLog("New clear strategy: " + newStrategy.GetType().ToString());
        }

        public void ChangeClearLimit(IClearLimit newLimit)
        {
            _clearLimit = newLimit;
            _logger.SaveLog("New clear limit: " + newLimit.GetType().ToString());
        }

        public void ChangeLoggingMethod(ILogging newLogger)
        {
            _logger = newLogger;
            _logger.SaveLog("New logger: " + newLogger.GetType().ToString());
        }

        private void SaveConfig()
        {
            using (FileStream fileStream = File.OpenWrite(_configPath))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                {
                    foreach (BackupJob job in _jobs)
                    {
                        ZipArchiveEntry fileInArchive = archive.CreateEntry(DateTime.Now.Ticks.ToString() + ".xml");
                        Stream entryStream = fileInArchive.Open();

                        var serializer = new DataContractSerializer(job.GetType());
                        var writer = XmlWriter.Create(entryStream, new XmlWriterSettings() { Indent = true });
                        serializer.WriteObject(writer, job);
                        writer.Close();
                        entryStream.Close();
                    }
                }
            }
        }

        private void LoadConfig()
        {
            if (File.Exists(_configPath))
            {
                using (FileStream fileStream = File.OpenRead(_configPath))
                {
                    using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Read, true))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            Stream entryStream = entry.Open();
                            var serializer = new DataContractSerializer(typeof(BackupJob));
                            var reader = XmlReader.Create(entryStream);
                            var job = (BackupJob)serializer.ReadObject(reader);

                            reader.Close();
                            entryStream.Close();

                            AddBackupJob(job);
                        }
                    }
                }

                File.Delete(_configPath);
            }
        }
    }
}
