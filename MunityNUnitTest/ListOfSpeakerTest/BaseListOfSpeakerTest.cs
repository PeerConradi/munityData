using MUNity.Models.ListOfSpeakers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.LoSExtensions;
using System.Linq;

namespace MunityNUnitTest.ListOfSpeakerTest
{
    /// <summary>
    /// Basic test cases for the list of speakers.
    /// </summary>
    public class BaseListOfSpeakerTest
    {
        /// <summary>
        /// Test creating an instance of a list of speakers.
        /// </summary>
        [Test]
        public void TestCreate()
        {
            var instance = new ListOfSpeakers();
            Assert.NotNull(instance);
            Assert.NotNull(instance.Speakers);
            Assert.NotNull(instance.Questions);
            Assert.IsNull(instance.CurrentQuestion);
            Assert.IsNull(instance.CurrentSpeaker);
        }

        /// <summary>
        /// Test add a speaker to the list of speakers.
        /// </summary>
        [Test]
        public void TestAddSpeaker()
        {
            var instance = new ListOfSpeakers();
            var speaker = instance.AddSpeaker("Speaker 1");
            Assert.NotNull(speaker);
            Assert.IsTrue(instance.Speakers.Any(n => n.Name == "Speaker 1"));
        }

        /// <summary>
        /// Test that calling the next speaker removes the speaker from the list.
        /// </summary>
        [Test]
        public void TestNextSpeakerRemovesFromList()
        {
            var instance = new ListOfSpeakers();
            var speaker = instance.AddSpeaker("Speaker 1");
            instance.NextSpeaker();
            Assert.IsFalse(instance.Speakers.Any());

        }

        /// <summary>
        /// Test that calling the next speaker sets the current speaker to the first speaker of the list.
        /// </summary>
        [Test]
        public void TestNextSpeakerSetsCurrentSpeaker()
        {
            var instance = new ListOfSpeakers();
            var speaker = instance.AddSpeaker("Speaker 1");
            instance.NextSpeaker();
            Assert.AreEqual(speaker, instance.CurrentSpeaker);
        }

        /// <summary>
        /// Test that when a Next speaker is set the Reamining Speaker time whill reset.
        /// In this case the list of speakers should be stopped and the SpeakerTime should be returned!
        /// </summary>
        [Test]
        public void TestNextSpeakerSettingTime()
        {
            var instance = new ListOfSpeakers();
            instance.SpeakerTime = new TimeSpan(0, 0, 0, 30);
            var speaker = instance.AddSpeaker("Speaker 1");
            instance.NextSpeaker();
            instance.StartSpeaker();
            Assert.IsTrue(instance.RemainingSpeakerTime.TotalSeconds >= 29 && instance.RemainingSpeakerTime.TotalSeconds < 31);
        }

        /// <summary>
        /// Test with a delay that the RemainingSpeakerTime is actually counting down.
        /// </summary>
        [Test]
        public void TestSpeakerListSpeakerCountDown()
        {
            var instance = new ListOfSpeakers();
            instance.SpeakerTime = new TimeSpan(0, 0, 0, 30);
            var speaker = instance.AddSpeaker("Speaker 1");
            instance.NextSpeaker();
            instance.StartSpeaker();
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(instance.RemainingSpeakerTime.TotalSeconds >= 24 && instance.RemainingSpeakerTime.TotalSeconds < 25);
        }

        [Test]
        public void TestAddQuestion()
        {
            var myListOfSpeakers = new ListOfSpeakers();
            var question = myListOfSpeakers.AddQuestion("Question 1");
        }
    }
}
