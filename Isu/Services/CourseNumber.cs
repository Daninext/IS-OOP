using System.Collections.Generic;

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