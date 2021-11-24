using System;

namespace IsuExtra.Tools
{
    public class TrainingSessionNotFoundIsuExtraException : IsuExtraException
    {
        public TrainingSessionNotFoundIsuExtraException()
        {
        }

        public TrainingSessionNotFoundIsuExtraException(string message)
            : base(message)
        {
        }

        public TrainingSessionNotFoundIsuExtraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
