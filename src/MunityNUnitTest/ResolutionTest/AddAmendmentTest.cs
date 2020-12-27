using MUNitySchema.Models.Resolution;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MUNity.Extensions.ResolutionExtensions;

namespace MunityNUnitTest.ResolutionTest
{
    public class AddAmendmentTest
    {
        [Test]
        public void TestCreateInstance()
        {
            var resolution = new Resolution();
            var paragraphOne = resolution.OperativeSection.CreateOperativeParagraph();
            var amendment = resolution.OperativeSection.CreateAddAmendment(1, "New Paragraph");
            Assert.NotNull(amendment);
            Assert.AreEqual(1, resolution.OperativeSection.AddAmendments.Count);
            Assert.AreEqual(2, resolution.OperativeSection.Paragraphs.Count);
            Assert.AreEqual(paragraphOne, resolution.OperativeSection.Paragraphs[0]);
            Assert.IsTrue(resolution.OperativeSection.Paragraphs[1].IsVirtual);
            Assert.Contains(amendment, resolution.OperativeSection.AddAmendments);
        }

        [Test]
        public void TestApplyAmendment()
        {
            var resolution = new Resolution();
            var paragraphOne = resolution.OperativeSection.CreateOperativeParagraph();
            var amendment = resolution.OperativeSection.CreateAddAmendment(1, "New Paragraph");
            amendment.Apply(resolution.OperativeSection);
            Assert.AreEqual(2, resolution.OperativeSection.Paragraphs.Count);
            Assert.AreEqual(paragraphOne, resolution.OperativeSection.Paragraphs[0]);
            Assert.AreEqual("New Paragraph", resolution.OperativeSection.Paragraphs[1].Text);
        }

        [Test]
        public void TestApplyAmendmentVirtualFalse()
        {
            var resolution = new Resolution();
            var paragraphOne = resolution.OperativeSection.CreateOperativeParagraph();
            var amendment = resolution.OperativeSection.CreateAddAmendment(1, "New Paragraph");
            amendment.Apply(resolution.OperativeSection);
            Assert.IsFalse(resolution.OperativeSection.Paragraphs[1].IsVirtual);
        }

        [Test]
        public void TestApplyAmendmentRemovesAmendment()
        {
            var resolution = new Resolution();
            var paragraphOne = resolution.OperativeSection.CreateOperativeParagraph();
            var amendment = resolution.OperativeSection.CreateAddAmendment(1, "New Paragraph");
            amendment.Apply(resolution.OperativeSection);
            Assert.IsFalse(resolution.OperativeSection.AddAmendments.Contains(amendment));
        }

        [Test]
        public void TestDeleteAddAmendment()
        {
            var resolution = new Resolution();
            var paragraphOne = resolution.OperativeSection.CreateOperativeParagraph();
            var amendment = resolution.OperativeSection.CreateAddAmendment(1, "New Paragraph");
            resolution.OperativeSection.RemoveAmendment(amendment);
            Assert.AreEqual(1, resolution.OperativeSection.Paragraphs.Count);
        }
    }
}
