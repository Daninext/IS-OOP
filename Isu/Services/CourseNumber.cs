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

        public static bool TryParse(string name, out CourseNumber number)
        {
            number = null;

            if (name.Length == 5 && name[0] == 'M' && int.TryParse(name[1].ToString(), out int temp) && temp == 3 && int.TryParse(name[2].ToString(), out int course) && int.TryParse(name.Substring(3, 2), out _))
            {
                CourseNumber courseNumber;
                courseNumber = new CourseNumber(course);
                number = courseNumber;

                return true;
            }

            return false;
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