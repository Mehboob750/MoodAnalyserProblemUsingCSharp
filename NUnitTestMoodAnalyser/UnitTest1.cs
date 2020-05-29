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
        public void When_GivenMessageNull_ShouldReturnHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser(null);
            string mood = moodAnalyser.AnalyseMood();
            Assert.AreEqual("Happy", mood);
        }

    }
}