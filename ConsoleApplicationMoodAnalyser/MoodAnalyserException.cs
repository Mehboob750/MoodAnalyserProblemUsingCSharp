using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationMoodAnalyser
{
    public class MoodAnalyserException : Exception
    {
        private ExceptionType claasNotFound;

        public enum ExceptionType
        {
            EnteredNull,EnteredEmpty, ClassNotFound
        }

        public ExceptionType type { get; set; }

        public MoodAnalyserException(ExceptionType type,string message)
            : base(message)
        {
            this.type = type;
        }

    }
}
