using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class CourseNumber
    {
        private List<Group> _groups = new List<Group>();
        private List<Student> _students = new List<Student>();

        private CourseNumber(int number)
        {
            Number = number;
        }

        public int Number { get; }

        public IReadOnlyList<Group> Groups { get => _groups; }

        public IReadOnlyList<Student> Students { get => _students; }

        public static CourseNumber Parse(string name)
        {
            if (name.Length != 5 || name[0] != 'M' || !int.TryParse(name[1].ToString(), out int temp) || temp != 3 || !int.TryParse(name[2].ToString(), out int course) || !int.TryParse(name.Substring(3, 2), out _))
                throw new GroupNameIsInvalidIsuException("The name of group is invalid!");

            return new CourseNumber(course);
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
    }
}