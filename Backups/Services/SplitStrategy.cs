using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Backups.Services
{
    public class SplitStrategy : IBackupStrategy
    {
        public void StartBackup(IReadOnlyList<JobObject> objects, RestorePoint point)
        {
            foreach (JobObject obj in objects)
            {
                var outStream = new MemoryStream();
                var archive = new ZipArchive(outStream, ZipArchiveMode.Create, true);

                ZipArchiveEntry fileInArchive = archive.CreateEntry(obj.Name);
                Stream entryStream = fileInArchive.Open();
                var fileToCompressStream = new MemoryStream(obj.Content);
                fileToCompressStream.CopyTo(entryStream);

                archive.Dispose();
                byte[] compressedBytes = outStream.ToArray();

                point.Repository.Save(compressedBytes, obj.Path, obj.Name);
            }
        }
    }
}
