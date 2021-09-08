namespace Isu.Services
{
    public class Student
    {
        public Student(CourseNumber courseNumber, Group group, string name)
        {
            Course = courseNumber;
            MyGroup = group;
            Name = name;
        }

        public CourseNumber Course { get; }

        public Group MyGroup { get; private set; }

        public string Name { get; }

        public void ChangeGroup(Group newGroup)
        {
            MyGroup.RemoveStudent(this);
            MyGroup = newGroup;
            newGroup.AddStudent(this);
        }
    }
}