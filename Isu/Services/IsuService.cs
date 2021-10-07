using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> _groups = new List<Group>();
        private List<Student> _students = new List<Student>();
        private List<CourseNumber> _courseNumbers = new List<CourseNumber>();

        public Group AddGroup(string name)
        {
            var courseNumber = CourseNumber.Parse(name);
            var group = new Group(courseNumber, name);
            courseNumber.AddGroup(group);
            _groups.Add(group);

            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            // The group must be in database, because we`ll add the student to this database
            if (!_groups.Contains(group))
                throw new GroupNotFoundIsuException("The group isn`t in the IsuService`s database!");

            var student = new Student(group, name);
            group.AddStudent(student);
            group.Course.AddStudent(student);
            _students.Add(student);

            return student;
        }

        public Student GetStudent(int id)
        {
            if (id >= _students.Count)
                throw new IncorrectIdIsuException("Id is invalid");

            return _students[id];
        }

        public Student FindStudent(string name)
        {
            foreach (Student stud in _students)
            {
                if (stud.Name == name)
                    return stud;
            }

            return null;
        }

        public IReadOnlyList<Student> FindStudents(string groupName)
        {
            Group temp = FindGroup(groupName);
            if (temp == null)
                return null;

            return temp.Students;
        }

        public IReadOnlyList<Student> FindStudents(CourseNumber courseNumber)
        {
            if (!_courseNumbers.Contains(courseNumber))
                return null;

            return courseNumber.Students;
        }

        public Group FindGroup(string groupName)
        {
            foreach (Group group in _groups)
            {
                if (group.Name == groupName)
                    return group;
            }

            return null;
        }

        public IReadOnlyList<Group> FindGroups(CourseNumber courseNumber)
        {
            if (!_courseNumbers.Contains(courseNumber))
                return null;

            return courseNumber.Groups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (!_students.Contains(student))
                throw new StudentNotFoundIsuException("The student isn`t in the IsuService`s database!");
            if (!newGroup.IsFreePlace())
                throw new GroupIsFullIsuException("There is no more free place in the new group!");

            student.ChangeGroup(newGroup);
        }
    }
}