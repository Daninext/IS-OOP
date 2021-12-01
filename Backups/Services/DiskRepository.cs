using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups.Services
{
    public class DiskRepository : IRepository
    {
        private string _path = @"C:\backups\";

        public IReadOnlyList<string> CreateBackUp(List<JobObject> objects, string mark)
        {
            if (objects.Count == 0)
                throw new Exception("Invalid");

            ZipArchive zip = CreateEmptyArchive(_path + mark + ".zip");

            var names = new List<string>();
            foreach (JobObject obj in objects)
            {
                zip.CreateEntryFromFile(obj.FileInf.FullName, obj.FileInf.Name);
                names.Add(obj.FileInf.FullName + mark);
            }

            return names;
        }

        public string CreateBackUp(JobObject jobject, string mark)
        {
            ZipArchive zip = CreateEmptyArchive(_path + jobject.FileInf.Name + mark + ".zip");

            zip.CreateEntryFromFile(jobject.FileInf.FullName, jobject.FileInf.Name);
            return jobject.FileInf.FullName + mark;
        }

        public void SetPath(string path)
        {
            _path = path;
        }

        private ZipArchive CreateEmptyArchive(string zipPath)
        {
            var dir = new DirectoryInfo(@".\temp");
            if (!dir.Exists)
            {
                dir.Create();
            }

            ZipFile.CreateFromDirectory(dir.FullName, zipPath);
            dir.Delete();

            var zipToOpen = new FileStream(zipPath, FileMode.Open);
            return new ZipArchive(zipToOpen, ZipArchiveMode.Update);
        }
    }
}
