using System;
using System.Collections.Generic;

namespace Backups.Services
{
    public class RestorePoint
    {
        private List<string> _fileNames = new List<string>();

        public RestorePoint(DateTime date, IReadOnlyList<string> fileNames)
        {
            CreatedDate = date;
            _fileNames.AddRange(fileNames);
        }

        public RestorePoint(DateTime date, string fileName)
        {
            CreatedDate = date;
            _fileNames.Add(fileName);
        }

        public DateTime CreatedDate { get; private set; }
        public IReadOnlyList<string> FileNames { get => _fileNames; }
    }
}
