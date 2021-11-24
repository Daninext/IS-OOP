using System.Collections.Generic;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuServiceExtra : IsuService
    {
        private List<GroupExtra> _groups = new List<GroupExtra>();
        private List<StudentExtra> _students = new List<StudentExtra>();
        private List<CourseNumber> _courseNumbers = new List<CourseNumber>();
        private List<CGTA> _cgta = new List<CGTA>();

        public new GroupExtra AddGroup(string name)
        {
            if (FindGroup(name) == null)
            {
                var courseNumber = CourseNumber.Parse(name);
                var group = new GroupExtra(courseNumber, name);
                courseNumber.AddGroup(group);
                _groups.Add(group);

                return group;
            }

            return FindGroup(name);
        }

        public StudentExtra AddStudent(GroupExtra group, string name)
        {
            if (!_groups.Contains(group))
                throw new GroupNotFoundIsuException("The group isn`t in the IsuService`s database!");

            var student = new StudentExtra(group, name);
            group.AddStudent(student);
            group.Course.AddStudent(student);
            _students.Add(student);

            return student;
        }

        public new StudentExtra GetStudent(int id)
        {
            if (id >= _students.Count)
                throw new IncorrectIdIsuException("Id is invalid");

            return _students[id];
        }

        public new StudentExtra FindStudent(string name)
        {
            foreach (StudentExtra studEx in _students)
            {
                if (studEx.Name == name)
                    return studEx;
            }

            return null;
        }

        public new GroupExtra FindGroup(string groupName)
        {
            foreach (GroupExtra group in _groups)
            {
                if (group.Name == groupName)
                    return group;
            }

            return null;
        }

        public CGTA AddCGTA(char megaFaculty, List<GroupExtra> groups = null)
        {
            if (FindCGTA(megaFaculty) == null)
            {
                var ncgta = new CGTA(megaFaculty, groups);
                _cgta.Add(ncgta);

                return ncgta;
            }

            return FindCGTA(megaFaculty);
        }

        public void AddGroupInCGTA(CGTA cgta, string name)
        {
            if (!_cgta.Contains(cgta))
                throw new CGTANotFoundIsuExtraException("The CGTA isn`t in the IsuService`s database!");

            cgta.AddGroup(new GroupExtra(CourseNumber.Parse(name), name));
        }

        public void SingUpForCGTA(CGTA cgta, StudentExtra student)
        {
            if (!_cgta.Contains(cgta))
                throw new CGTANotFoundIsuExtraException("The CGTA isn`t in the IsuService`s database!");

            cgta.AddStudent(student);
        }

        public void RemoveFromCGTA(CGTA cgta, StudentExtra student)
        {
            if (!_cgta.Contains(cgta))
                throw new CGTANotFoundIsuExtraException("The CGTA isn`t in the IsuService`s database!");

            cgta.RemoveStudent(student);
        }

        public CGTA FindCGTA(char megaFaculty)
        {
            foreach (CGTA cgta in _cgta)
            {
                if (cgta.MegaFaculty == megaFaculty)
                    return cgta;
            }

            return null;
        }

        public IReadOnlyList<StudentExtra> FindStudentsFromCGTA(CGTA cgta)
        {
            if (!_cgta.Contains(cgta))
                throw new CGTANotFoundIsuExtraException("The CGTA isn`t in the IsuService`s database!");

            var students = new List<StudentExtra>();
            foreach (GroupExtra group in cgta.Groups)
            {
                students.AddRange(group.Students);
            }

            return students;
        }

        public IReadOnlyList<StudentExtra> FindFreeStudents(GroupExtra group)
        {
            if (FindGroup(group.Name) == null)
                throw new GroupNotFoundIsuException("The group isn`t in the IsuService`s database!");

            var students = new List<StudentExtra>();
            foreach (StudentExtra student in group.Students)
            {
                if (student.CGTAs.Count == 0)
                    students.Add(student);
            }

            return students;
        }
    }
}
