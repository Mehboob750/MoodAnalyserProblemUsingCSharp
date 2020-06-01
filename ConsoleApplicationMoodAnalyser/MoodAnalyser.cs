using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationMoodAnalyser
{
    public class MoodAnalyser
    {
        private string message;

        public MoodAnalyser() { }

        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string AnalyseMood()
        {
            try
            {
                if (message.Length == 0)
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EnteredEmpty, "Please Enter Proper Mood");
                if (message.Contains("Sad"))
                    return "Sad";
                return "Happy";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EnteredNull, "Please Enter Proper Mood");
            }
        }
    }
}
