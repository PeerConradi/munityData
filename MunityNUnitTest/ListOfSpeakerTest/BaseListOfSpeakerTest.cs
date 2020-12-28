using MUNitySchema.Models.ListOfSpeakers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.LoSExtensions;
using System.Linq;

namespace MunityNUnitTest.ListOfSpeakerTest
{
    class BaseListOfSpeakerTest
    {
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

        [Test]
        public void TestAddSpeaker()
        {
            var instance = new ListOfSpeakers();
            var speaker = instance.AddSpeaker("Speaker 1");
            Assert.NotNull(speaker);
            Assert.Contains(speaker, instance.Speakers);
        }

        [Test]
        public void TestNextSpeakerRemovesFromList()
        {
            var instance = new ListOfSpeakers();
            var speaker = instance.AddSpeaker("Speaker 1");
            instance.NextSpeaker();
            Assert.IsFalse(instance.Speakers.Any());

        }

        [Test]
        public void TestNextSpeakerSetsCurrentSpeaker()
        {
            var instance = new ListOfSpeakers();
            var speaker = instance.AddSpeaker("Speaker 1");
            instance.NextSpeaker();
            Assert.AreEqual(speaker, instance.CurrentSpeaker);
        }


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
    }
}
