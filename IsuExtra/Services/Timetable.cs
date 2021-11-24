using System;
using System.Collections.Generic;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class Timetable
    {
        private readonly TimeSpan timeOfSession = new TimeSpan(0, 1, 30, 0);
        private List<TrainingSession> _sessions = new List<TrainingSession>();

        public Timetable(List<TrainingSession> newSessions)
        {
            if (newSessions != null)
            {
                foreach (TrainingSession session in _sessions)
                {
                    AddSession(session);
                }
            }
        }

        public Timetable(TrainingSession newSession = null)
        {
            if (newSession != null)
                _sessions.Add(newSession);
        }

        public IReadOnlyList<TrainingSession> Sessions { get => _sessions; }

        public void AddSession(TrainingSession newSession)
        {
            if (newSession == null)
                throw new TrainingSessionNotFoundIsuExtraException("Session was NULL");
            if (!IsFreeTime(newSession))
                throw new InvalidTimeIsuExtraException("Incorrect time");

            _sessions.Add(newSession);
        }

        public bool IsFreeTime(TrainingSession newSession)
        {
            if (newSession == null)
                throw new TrainingSessionNotFoundIsuExtraException("Session was NULL");

            foreach (TrainingSession session in _sessions)
            {
                if (Math.Abs(session.TimeStart.TotalMinutes - newSession.TimeStart.TotalMinutes) < timeOfSession.TotalMinutes)
                    return false;
            }

            return true;
        }
    }
}
