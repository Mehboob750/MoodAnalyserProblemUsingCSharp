using System;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using ConsoleApplicationMoodAnalyser;
using NUnit.Framework;

namespace NUnitTestMoodAnalyser
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenMessage_WhenContainsSad_ShouldReturnSad()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Sad Mood");
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("Sad",mood);
        }

        [Test]
        public void GivenMessage_WhenAnyMood_ShouldReturnHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Any Mood");
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("Happy", mood);
        }

        [Test]
        public void GivenMessage_WhenNull_ShouldThrowException()
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EnteredNull, e.type);
            }
        }

        [Test]
        public void GivenMessage_WhenEmpty_ShouldThrowException()
        {
            try
            {
                MoodAnalyser moodAnalyser = new MoodAnalyser(" ");
                moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.EnteredEmpty, e.type);
            }
        }

        [Test]
        public void GivenClassName_WhenProper_ShouldReturnObject()
        {
            MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser("ConsoleApplicationMoodAnalyser.MoodAnalyser");
            bool result = moodAnalyser.Equals((MoodAnalyser)new MoodAnalyser());
            Assert.AreEqual(result,false);
        }

        [Test]
        public void GivenClassName_WhenNotProper_ShouldThrowException()
        {
            try
            {
                MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser("Wrong Class Name");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ClassNotFound, e.type);
            }
        }

        [Test]
        public void GivenClassNameAndConstructor_WhenWrongConstructor_ShouldThrowException()
        {
            try
            {
                Object moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser("ConsoleApplicationMoodAnalyser.MoodAnalyser");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.MethodNotFound,e.type);

            }
        }

        [Test]
        public void GivenClassNameWithParametrizedConstructor_WhenProper_ShouldReturnObject()
        {
            MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser("ConsoleApplicationMoodAnalyser.MoodAnalyser", "I am in Sad Mood");
            bool result = moodAnalyser.Equals((MoodAnalyser)new MoodAnalyser());
            Assert.AreEqual(result, false);
        }

        [Test]
        public void GivenClassNameParametrizedConstructor_WhenNotProper_ShouldThrowException()
        {
            try
            {
                MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser("Wrong Class Name","I am in Sad Mood");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ClassNotFound, e.type);
            }
        }
    }
}