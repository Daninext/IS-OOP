﻿using System.Collections.Generic;

namespace Isu.Services
{
    public interface IIsuService
    {
        Group AddGroup(string name);

        Student AddStudent(Group group, string name);

        Student GetStudent(int id);
        Student FindStudent(string name);
        IReadOnlyList<Student> FindStudents(string groupName);
        IReadOnlyList<Student> FindStudents(CourseNumber courseNumber);

        Group FindGroup(string groupName);
        IReadOnlyList<Group> FindGroups(CourseNumber courseNumber);

        void ChangeStudentGroup(Student student, Group newGroup);
    }
}