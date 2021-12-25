using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backups.Tools;

namespace Backups.Services
{
    public class VirtualRepository : IRepository
    {
        private const string SPLITER = "#%#%#"; // It is used for split different files in a single bytes array
        private Dictionary<string, byte[]> _virtualDirectory = new Dictionary<string, byte[]>();
        public IReadOnlyDictionary<string, byte[]> VirtualDirectory { get => _virtualDirectory; }

        public IReadOnlyList<string> CreateBackUp(IReadOnlyList<JobObject> objects, string mark)
        {
            if (objects.Count == 0)
                throw new JobObjectNotFoundBackUpException("Job object not found");

            byte[] byteData = ConvertDataToBytes(objects);
            List<string> names = GetSavedFileNames(objects, mark);

            if (objects.Count > 1)
            {
                SaveInDirectory(byteData, mark);
            }
            else
            {
                SaveInDirectory(byteData, names[0] + mark);
            }

            return names;
        }

        private byte[] ConvertDataToBytes(IReadOnlyList<JobObject> objects)
        {
            byte[] result = Encoding.ASCII.GetBytes(SPLITER);

            foreach (JobObject obj in objects)
            {
                result = result.Concat(obj.Content).ToArray();
                result = result.Concat(Encoding.ASCII.GetBytes(SPLITER)).ToArray();
            }

            return result;
        }

        private List<string> GetSavedFileNames(IReadOnlyList<JobObject> objects, string mark)
        {
            var names = new List<string>();
            int counter = 1;
            foreach (JobObject obj in objects)
            {
                if (obj.FileInf != null)
                {
                    names.Add(obj.FileInf.FullName + mark);
                }
                else
                {
                    names.Add("WithoutName" + counter.ToString() + mark);
                    ++counter;
                }
            }

            return names;
        }

        private void SaveInDirectory(byte[] data, string mark)
        {
            if (!_virtualDirectory.ContainsKey(mark + ".zip"))
            {
                _virtualDirectory.Add(mark + ".zip", data);
                return;
            }

            for (int i = 1; ; ++i)
            {
                if (!_virtualDirectory.ContainsKey(i.ToString() + mark + ".zip"))
                {
                    _virtualDirectory.Add(i.ToString() + mark + ".zip", data);
                    return;
                }
            }
        }
    }
}
