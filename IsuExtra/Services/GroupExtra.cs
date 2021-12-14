using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;

namespace IsuExtra.Services
{
    public class GroupExtra : Group
    {
        private const int MAXCOUNTSTUDENTS = 25;

        private List<StudentExtra> _students = new List<StudentExtra>();
        private Timetable _timetable;
        public GroupExtra(CourseNumber courseNumber, string name, Timetable timetable = null)
            : base(courseNumber, name)
        {
            if (timetable == null)
                _timetable = new Timetable();
            else
                _timetable = timetable;
        }

        public GroupExtra(Group group, Timetable timetable = null)
            : base(group.Course, group.Name)
        {
            if (timetable == null)
                _timetable = new Timetable();
            else
                _timetable = timetable;
        }

        public new IReadOnlyList<StudentExtra> Students { get => _students; }

        public IReadOnlyList<TrainingSession> Sessions { get => _timetable.Sessions; }

        public void AddSession(TrainingSession newSession)
        {
            _timetable.AddSession(newSession);
        }

        public bool IsFreeTimeForSessions(IReadOnlyList<TrainingSession> sessions)
        {
            foreach (TrainingSession session in sessions)
            {
                if (_timetable.IsFreeTime(session) == false)
                    return false;
            }

            return true;
        }

        public void AddStudent(StudentExtra student)
        {
            if (!IsFreePlace())
                throw new GroupIsFullIsuException("There is no more free place in the group!");

            _students.Add(student);
        }

        public void RemoveStudent(StudentExtra student)
        {
            _students.Remove(student);
        }

        public new bool IsFreePlace()
        {
            return !(_students.Count >= MAXCOUNTSTUDENTS);
        }
    }
}
