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
            if (CourseNumber.TryParse(name, out CourseNumber courseNumber))
            {
                var group = new Group(courseNumber, name);
                courseNumber.AddGroup(group);
                _groups.Add(group);
                return group;
            }
            else
            {
                throw new IsuException("The name of group is invalid!");
            }
        }

        public Student AddStudent(Group group, string name)
        {
            // The group must be in database, because we`ll add the student to this database
            if (!_groups.Contains(group))
            {
                throw new GroupNotFoundIsuException("The group isn`t in the IsuService`s database!");
            }

            if (group.IsFreePlace())
            {
                var student = new Student(group, name);
                group.Course.AddStudent(student);
                _students.Add(student);
                group.AddStudent(student);
                return student;
            }
            else
            {
                throw new IsuException("There is no more free place in the group!");
            }
        }

        public Student GetStudent(int id)
        {
            if (id < _students.Count)
            {
                return _students[id];
            }

            throw new IsuException("Id is invalid");
        }

        public Student FindStudent(string name)
        {
            foreach (Student stud in _students)
            {
                if (stud.Name == name)
                {
                    return stud;
                }
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            Group temp = FindGroup(groupName);
            if (temp != null)
                return temp.Students;

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
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
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            if (!_courseNumbers.Contains(courseNumber))
                return null;

            return courseNumber.Groups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (!_students.Contains(student))
                throw new IsuException("The student isn`t in the IsuService`s database!");
            if (!newGroup.IsFreePlace())
                throw new IsuException("There is no more free place in the new group!");

            student.ChangeGroup(newGroup);
        }
    }
}