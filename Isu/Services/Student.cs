namespace Isu.Services
{
    public class Student
    {
        public Student(Group group, string name)
        {
            MyGroup = group;
            Name = name;
        }

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