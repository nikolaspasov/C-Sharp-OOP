namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class ComputerTests
    {
        Computer comp;
        [SetUp]
        public void Setup()
        {
            comp = new Computer("TestPC");
        }

        [Test]
        public void ThrowExceptionIfNameIsNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer("");
            });
        }
        [Test]
        public void NameSetCorrectly()
        {
            Computer computer = new Computer("Test123");
            Assert.AreEqual("Test123", computer.Name);
        }
        [Test]
        public void TotalPriceSetCorrectly()
        {
            Part part1 = new Part("TestPart1", 100);
            Part part2 = new Part("TestPart2", 10);

            comp.AddPart(part1);
            comp.AddPart(part2);
            Assert.AreEqual(110,comp.TotalPrice );
        }
        [Test]
        public void AddMethodThrowsExceptionIsPartIsNull()
        {
            Part part1 = null;
            Assert.Throws<InvalidOperationException>(() =>
            {
                comp.AddPart(part1);
            });

        }
        [Test]
        public void AddMethodWorksCorrectly()
        {
            Part part1 = new Part("TestPart1", 100);
            comp.AddPart(part1);
            comp.AddPart(part1);
            Assert.AreEqual(comp.Parts.Count, 2);
           
        }
        [Test]
        public void RemovePartWorksCorrectly()
        {
            Part part1 = new Part("TestPart1", 100);
            comp.AddPart(part1);

            Assert.AreEqual(comp.RemovePart(part1),true);
        }
        [Test]
        public void GetPartWorksCorrectly()
        {
            Part part1 = new Part("TestPart1", 100);
            Part part2 = new Part("TestPart2", 10);
            comp.AddPart(part1);
            comp.AddPart(part2);

            var getPart = comp.GetPart("TestPart1");
            Assert.AreEqual(getPart, part1);
        }
        
    }
}