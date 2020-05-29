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
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            string mood = moodAnalyser.AnalyseMood("I am in Sad Mood");
            Assert.AreEqual("Sad",mood);
        }

        [Test]
        public void When_GivenMessageAnyMood_ShouldReturnHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser();
            string mood = moodAnalyser.AnalyseMood("I am in Any Mood");
            Assert.AreEqual("Happy", mood);
        }

    }
}