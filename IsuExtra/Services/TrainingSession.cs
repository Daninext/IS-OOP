using System;
using System.Collections.Generic;
using Isu.Services;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class TrainingSession
    {
        private List<Group> _groups = new List<Group>();
        private TimeSpan _timeStart;

        public TrainingSession(Teacher teacher, TimeSpan timeStart, LectureHall lectureHall, List<Group> groups = null)
        {
            SessionTeacher = teacher ?? throw new TeacherNotFoundIsuExtraException("Teacher was NULL");
            TimeStart = timeStart;
            ChangeHall(lectureHall);
            AddGroups(groups);
        }

        public IReadOnlyList<Group> Groups { get => _groups; }
        public Teacher SessionTeacher { get; private set; }
        public TimeSpan TimeStart
        {
            get => _timeStart;
            set
            {
                if (value == TimeSpan.Zero)
                    throw new InvalidTimeIsuExtraException("Invalid time");

                _timeStart = new TimeSpan(value.Days % 7, value.Hours, value.Minutes, 0);
            }
        }

        public LectureHall Hall { get; private set; }

        public void AddGroups(List<Group> groups)
        {
            if (groups != null)
                _groups.AddRange(groups);
        }

        public void AddGroup(Group group)
        {
            if (group != null)
                _groups.Add(group);
        }

        public void ChangeHall(LectureHall lectureHall)
        {
            Hall = lectureHall ?? throw new LectureHallNotFoundIsuExtraException("Lecture hall was NULL");
        }

        public void ChangeTime(TimeSpan time)
        {
            TimeStart = time;
        }
    }
}
