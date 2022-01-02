using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups.Services
{
    public class SingleStrategy : IBackupStrategy
    {
        public void StartBackup(IReadOnlyList<JobObject> objects, RestorePoint point)
        {
            var outStream = new MemoryStream();
            var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true);

            foreach (JobObject obj in objects)
            {
                ZipArchiveEntry fileInArchive = archive.CreateEntry(obj.Name);
                Stream entryStream = fileInArchive.Open();
                var fileToCompressStream = new MemoryStream(obj.Content);
                fileToCompressStream.CopyTo(entryStream);

                entryStream.Close();
            }

            archive.Dispose();
            byte[] compressedBytes = outStream.ToArray();

            point.Repository.Save(compressedBytes, "all");
        }
    }
}
