﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApplicationMoodAnalyser
{
    public class MoodAnalyserFactory
    { 
        public MoodAnalyserFactory()
        {
        }

        public static MoodAnalyser CreateMoodAnalyser(string ClassName, params object[] constructor)
        {
            Type type = Type.GetType(ClassName);
            if (type == null)
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ClassNotFound,"Class Not Found");
            try
            {
                var ObjectInstance = Activator.CreateInstance(type, constructor);
                if (ObjectInstance == null)
                    throw new MissingMethodException(MoodAnalyserException.ExceptionType.MethodNotFound+"Method Not Found");
                return (MoodAnalyser)ObjectInstance;
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.MethodNotFound, "Method Not Found");
            }
        }

        public static string InvokeMethodUsingReflection(string methodName,string message)
        {
            try
            {
                MethodBase method = typeof(MoodAnalyser).GetMethod(methodName);
                object objectInstance = Activator.CreateInstance(typeof(MoodAnalyser), message);
                string mood = (string)method.Invoke(objectInstance, null);
                return mood;
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.MethodNotFound, "Method Not Found");
            }

        }

    }
}
