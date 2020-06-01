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
        public void When_GivenMessageContainsSad_ShouldReturnSad()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Sad Mood");
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("Sad",mood);
        }

        [Test]
        public void When_GivenMessageAnyMood_ShouldReturnHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Any Mood");
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("Happy", mood);
        }

        [Test]
        public void When_GivenMessageNull_ShouldThrowException()
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
        public void When_GivenMessageEmpty_ShouldThrowException()
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
        public void GivenMoodAnalyserClass_WhenProper_ShouldReturnObject()
        {
            MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyser("ConsoleApplicationMoodAnalyser.MoodAnalyser");
            bool result = moodAnalyser.Equals((MoodAnalyser)new MoodAnalyser());
            Assert.AreEqual(result,false);
        }

        [Test]
        public void GivenMoodAnalyserClass_WhenNotProper_ShouldThrowException()
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
        public void GivenMoodAnalyserClass_WhenWrongConstructor_ShouldThrowException()
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
    }
}