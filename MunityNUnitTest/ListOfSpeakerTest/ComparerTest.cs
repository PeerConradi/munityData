using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MunityNUnitTest.ListOfSpeakerTest
{
    public class ComparerTest
    {
        [Test]
        public void TestInitWithSameId()
        {
            var listOne = new MUNity.Models.ListOfSpeakers.ListOfSpeakers();
            var listTwo = new MUNity.Models.ListOfSpeakers.ListOfSpeakers();
            listTwo.ListOfSpeakersId = listOne.ListOfSpeakersId;
            var result = listOne.CompareTo(listTwo);
            Assert.AreEqual(0, result);
        }
    }
}
