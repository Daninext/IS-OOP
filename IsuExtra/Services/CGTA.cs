using System;
using System.Collections.Generic;
using System.Linq;
using Isu.Tools;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class CGTA
    {
        private const int MAXCGTACOUNT = 2;
        private List<GroupExtra> _groups = new List<GroupExtra>();

        public CGTA(char megaFaculty, List<GroupExtra> groups = null)
        {
            MegaFaculty = megaFaculty;

            if (groups != null)
                groups.AddRange(groups);
        }

        public char MegaFaculty { get; }
        public IReadOnlyList<GroupExtra> Groups { get => _groups; }

        public void AddGroup(GroupExtra group)
        {
            _groups.Add(group);
        }

        public void AddStudent(StudentExtra student)
        {
            if (student.MyGroup.Name[0] == MegaFaculty)
                throw new InvalidStudentCGTADataIsuExtraException("Same MegaFaculty");
            if (student.CGTAs.Contains(this))
                throw new InvalidStudentCGTADataIsuExtraException("Already in CGTA");
            if (student.CGTAs.Count == MAXCGTACOUNT)
                throw new InvalidStudentCGTADataIsuExtraException("Max count of CGTA");

            var suitableGroups = new List<GroupExtra>();
            foreach (GroupExtra group in _groups)
            {
                if (group.IsFreePlace())
                {
                    suitableGroups.Add(group);
                }
            }

            if (suitableGroups.Count == 0)
                throw new GroupIsFullIsuException("There is no more free place");

            foreach (GroupExtra group in suitableGroups)
            {
                if (group.IsFreeTimeForSessions(student.AllSessions))
                {
                    student.AddCGTA(this);
                    group.AddStudent(student);
                    return;
                }
            }

            throw new InvalidTimeIsuExtraException("There is no more free time");
        }

        public void RemoveStudent(StudentExtra student)
        {
            if (!student.CGTAs.Contains(this))
                throw new StudentNotFoundIsuException("Student is not in CGTA");

            foreach (GroupExtra group in _groups)
            {
                if (group.Students.Contains(student))
                {
                    student.RemoveCGTA(this);
                    group.RemoveStudent(student);
                    return;
                }
            }
        }

        public GroupExtra FindGroup(StudentExtra student)
        {
            foreach (GroupExtra group in _groups)
            {
                if (group.Students.Contains(student))
                {
                    return group;
                }
            }

            return null;
        }
    }
}
