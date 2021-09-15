using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class CourseNumber
    {
        public CourseNumber(int number)
        {
            Number = number;
        }

        public int Number { get; }

        public List<Group> Groups { get; } = new List<Group>();

        public List<Student> Students { get; } = new List<Student>();

        public static CourseNumber Parse(string name)
        {
            if (name.Length == 5 && name[0] == 'M' && int.TryParse(name[1].ToString(), out int temp) && temp == 3 && int.TryParse(name[2].ToString(), out int course) && int.TryParse(name.Substring(3, 2), out _))
                return new CourseNumber(course);
            else
                throw new GroupNameIsInvalidIsuException("The name of group is invalid!");
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}