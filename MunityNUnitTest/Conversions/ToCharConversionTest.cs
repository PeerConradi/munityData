using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.Conversion;

namespace MunityNUnitTest.Conversions
{
    public class ToCharConversionTest
    {
        [Test]
        public void TestZeroReturnsA()
        {
            int i = 0;
            string res = i.ToLetter();
            Assert.AreEqual("a", res);
        }

        [Test]
        public void TestTwentyFiveIsZ()
        {
            int i = 25;
            string res = i.ToLetter();
            Assert.AreEqual("z", res);
        }

        [Test]
        public void TestTwentySixIsAA()
        {
            int i = 26;
            string res = i.ToLetter();
            Assert.AreEqual("aa", res);
        }

        [Test]
        public void TestTwentySevenIsAB()
        {
            int i = 27;
            string res = i.ToLetter();
            Assert.AreEqual("ab", res);
        }

        [Test]
        public void TestLettersZeroToOneHundred()
        {
            for (int i=0;i<=100;i++)
            {
                Console.WriteLine($"{i}\t{i.ToLetter()}");
            }
        }
    }
}
