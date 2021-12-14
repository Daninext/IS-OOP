using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Isu.Services;

[assembly: InternalsVisibleTo("CGTA")]
namespace IsuExtra.Services
{
    public class StudentExtra : Student
    {
        private List<CGTA> _cgta = new List<CGTA>();

        public StudentExtra(GroupExtra group, string name)
            : base(group, name)
        {
            MyGroup = group;
        }

        public new GroupExtra MyGroup { get; private set; }

        public IReadOnlyList<CGTA> CGTAs { get => _cgta; }

        public IReadOnlyList<TrainingSession> AllSessions
        {
            get
            {
                var sessions = new List<TrainingSession>();
                sessions.AddRange(MyGroup.Sessions);
                foreach (CGTA cgta in _cgta)
                {
                    sessions.AddRange(cgta.FindGroup(this).Sessions);
                }

                return sessions;
            }
        }

        internal void AddCGTA(CGTA cgta)
        {
            _cgta.Add(cgta);
        }

        internal void RemoveCGTA(CGTA cgta)
        {
            _cgta.Remove(cgta);
        }
    }
}
