using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplicationMoodAnalyser
{
    public class MoodAnalyserFactory
    { 
        public MoodAnalyserFactory()
        {
        }


        public static MoodAnalyser CreateMoodAnalyser(string ClassName)
        {
            Type type = Type.GetType(ClassName);
            var ObjectInstance = Activator.CreateInstance(type);
            return (MoodAnalyser)ObjectInstance;
        }
    }
}
