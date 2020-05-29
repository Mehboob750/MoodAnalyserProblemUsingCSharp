using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationMoodAnalyser
{
    public class MoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            EnteredNull,EnteredEmpty
        }

        public ExceptionType type { get; set; }

        public MoodAnalyserException(ExceptionType type,string message)
            : base(message)
        {
            this.type = type;
        }
    }
}
