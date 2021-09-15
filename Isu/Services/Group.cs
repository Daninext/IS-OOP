﻿using System.Collections.Generic;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private const int MAXCOUNTSTUDENTS = 25;

        public Group(CourseNumber courseNumber, string name)
        {
            Course = courseNumber;
            Name = name;
        }

        public CourseNumber Course { get; }

        public string Name { get; }

        public List<Student> Students { get; } = new List<Student>();

        public void AddStudent(Student student)
        {
            if (IsFreePlace())
                Students.Add(student);
            else
                throw new GroupIsFullIsuException("There is no more free place in the group!");
        }

        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public bool IsFreePlace()
        {
            return !(Students.Count >= MAXCOUNTSTUDENTS);
        }
    }
}