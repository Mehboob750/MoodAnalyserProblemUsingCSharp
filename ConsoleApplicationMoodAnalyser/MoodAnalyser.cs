using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationMoodAnalyser
{
    public class MoodAnalyser
    {
        public string AnalyseMood(string message)
        {
            if (message.Contains("Sad"))
                return "Sad";
            return "Happy";
        }
    }
}
