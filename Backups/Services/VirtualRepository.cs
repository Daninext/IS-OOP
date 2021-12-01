using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Backups.Services
{
    public class VirtualRepository : IRepository
    {
        private const string SPLITER = "#%#%#";
        private Dictionary<string, byte[]> _virtualDirectory = new Dictionary<string, byte[]>();
        public IReadOnlyDictionary<string, byte[]> VirtualDirectory { get => _virtualDirectory; }

        public IReadOnlyList<string> CreateBackUp(List<JobObject> objects, string mark)
        {
            byte[] result = Encoding.ASCII.GetBytes(SPLITER);

            var names = new List<string>();
            int counter = 1;
            foreach (JobObject obj in objects)
            {
                result = result.Concat(obj.Content).ToArray();
                result = result.Concat(Encoding.ASCII.GetBytes(SPLITER)).ToArray();
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

            if (!_virtualDirectory.ContainsKey(mark + ".zip"))
            {
                _virtualDirectory.Add(mark + ".zip", result);
            }
            else
            {
                for (int i = 1; ; ++i)
                {
                    if (!_virtualDirectory.ContainsKey(i.ToString() + mark + ".zip"))
                    {
                        _virtualDirectory.Add(i.ToString() + mark + ".zip", result);
                        break;
                    }
                }
            }

            return names;
        }

        public string CreateBackUp(JobObject jobject, string mark)
        {
            if (jobject.FileInf != null)
            {
                if (!_virtualDirectory.ContainsKey(jobject.FileInf.Name + mark + ".zip"))
                {
                    _virtualDirectory.Add(jobject.FileInf.Name + mark + ".zip", File.ReadAllBytes(jobject.FileInf.FullName));
                }
                else
                {
                    for (int i = 1; ; ++i)
                    {
                        if (!_virtualDirectory.ContainsKey(jobject.FileInf.Name + i.ToString() + mark + ".zip"))
                        {
                            _virtualDirectory.Add(jobject.FileInf.Name + i.ToString() + mark + ".zip", File.ReadAllBytes(jobject.FileInf.FullName));
                            break;
                        }
                    }
                }

                return jobject.FileInf.FullName + mark;
            }
            else
            {
                if (!_virtualDirectory.ContainsKey("WithoutName" + mark + ".zip"))
                {
                    _virtualDirectory.Add("WithoutName" + mark + ".zip", jobject.Content);
                }
                else
                {
                    for (int i = 1; ; ++i)
                    {
                        if (!_virtualDirectory.ContainsKey("WithoutName" + i.ToString() + mark + ".zip"))
                        {
                            _virtualDirectory.Add("WithoutName" + i.ToString() + mark + ".zip", jobject.Content);
                            break;
                        }
                    }
                }

                return "WithoutName" + mark;
            }
        }
    }
}
