﻿using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private const int MAXCOUNTSTUDENTS = 25;

        private List<Student> _students = new List<Student>();

        public Group(CourseNumber courseNumber, string name)
        {
            Course = courseNumber;
            Name = name;
        }

        public CourseNumber Course { get; }

        public string Name { get; }

        public IReadOnlyList<Student> Students { get => _students; }

        public void AddStudent(Student student)
        {
            if (!IsFreePlace())
                throw new GroupIsFullIsuException("There is no more free place in the group!");

            _students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            _students.Remove(student);
        }

        public bool IsFreePlace()
        {
            return !(_students.Count >= MAXCOUNTSTUDENTS);
        }
    }
}