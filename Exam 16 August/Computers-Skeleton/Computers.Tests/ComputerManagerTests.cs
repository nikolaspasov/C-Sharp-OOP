using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        ComputerManager compManager;
        [SetUp]
        public void Setup()
        {
            this.compManager = new ComputerManager();
        }
       
        [Test]
        public void CheckIfConstructorWorksCorrectly()
        {
            Assert.That(this.compManager.Count, Is.EqualTo(0));
            Assert.That(this.compManager.Computers, Is.Empty);
        }
        [Test]
        public void CountWorksCorrectly()
        {
            this.compManager.AddComputer(new Computer("Test", "Model", 123));
            Assert.AreEqual(1, compManager.Count);
        }
        [Test]
        public void AddComputerThrowsExceptionIfObjectDoesNotExist()
        {
            Computer comp = null;
             Assert.Throws<ArgumentNullException>(()=>
             compManager.AddComputer(comp));
        }
        [Test]
        public void AddComputerThrowsExceptionIfObjectAlreadyExists()
        {
            
            Assert.Throws<ArgumentException>(()=>
            {

                Computer comp = new Computer("Test", "Model", 10);
                compManager.AddComputer(comp);
                compManager.AddComputer(comp);

            });
        }
        [Test]
        public void AddComputerWorksCorrectly()
        {
            Computer comp = new Computer("Test", "Model", 10);
            Computer comp1 = new Computer("Test1", "Model1", 10);
            compManager.AddComputer(comp);
            compManager.AddComputer(comp1);
            Assert.AreEqual(2, compManager.Computers.Count);
        }
        [Test]
        public void RemoveComputerWorksCorrectly()
        {
            Computer comp = new Computer("Test", "Model", 10);
            
            compManager.AddComputer(comp);
            
           var removedComp= compManager.RemoveComputer("Test","Model");
            Assert.AreEqual(0, compManager.Computers.Count);
            Assert.AreSame(removedComp, comp);
        }
        [Test]
        public void GetComputerThrowsExceptionIfComputerDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
               
                compManager.GetComputer("TestManufacturer","TestModel");

            });
            
        }
        [Test]
        public void GetComputerWorksCorrectly()
        {
            compManager.AddComputer(new Computer("TestManufacturer", "TestModel",100));
            var comp = compManager.GetComputer("TestManufacturer","TestModel");
            Assert.AreEqual(comp.Manufacturer, "TestManufacturer");
            Assert.AreEqual(comp.Model, "TestModel");
        }
        [Test]
        public void GetComputerThrowsExceptionWithNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {

                compManager.GetComputer(null, "TestModel");

            });

        }
         [Test]
        public void GetComputerThrowsExceptionWithNullModel()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {

                compManager.GetComputer("Test", null);

            });

        }
        [Test]
        public void GetComputerByManufacturerWorksCorrectly()
        {
            compManager.AddComputer(new Computer("TestManufacturer", "TestModel", 100));
            compManager.AddComputer(new Computer("TestManufacturer", "testModel123", 100));
            compManager.AddComputer(new Computer("NotTest", "testModel123", 100));

            var comp = compManager.GetComputersByManufacturer("TestManufacturer");
            Assert.That(comp.Count, Is.EqualTo(2));


        }
         [Test]
        public void GetComputerByManufacturerThrowsExceptionWithNullManufacturer()
        {
            compManager.AddComputer(new Computer("TestManufacturer", "TestModel", 100));
            compManager.AddComputer(new Computer("TestManufacturer", "testModel123", 100));
            compManager.AddComputer(new Computer("TestManufacturer2", "testModel1323", 100));
            Assert.Throws<ArgumentNullException>(() =>
            {
                var comp = compManager.GetComputersByManufacturer(null);
            });
         
        } 
       
       

       


    }
}