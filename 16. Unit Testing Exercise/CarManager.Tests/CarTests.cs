using NUnit.Framework;

namespace Tests
{
    using CarManager;
    using NUnit.Framework.Internal;
    using System;

    public class CarTests
    {
        Car newCar;
        [SetUp]
        public void Setup()
        {
            newCar = new Car("VW", "Golf", 10, 100);
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.AreEqual(newCar.Make, "VW");
            Assert.AreEqual(newCar.Model, "Golf");
            Assert.AreEqual(newCar.FuelConsumption, 10);
            Assert.AreEqual(newCar.FuelCapacity, 100);
            Assert.AreEqual(newCar.FuelAmount, 0);
        }
        [Test]
        public void MakeThrowsExceptionIfNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car("", "123", 123, 123);
            });
        }
        [Test]
        public void ModelThrowsExceptionIfNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car("123", null, 123, 123);
            });
        }
        [Test]
        public void FuelConsumptionThrowsExceptionIfZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car("123", "123", -12, 123);
            });
        }
        [Test]
        public void FuelCapacityThrowsExceptionIfZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testCar = new Car("123", "123", 2, -12);
            });
        }
        [Test]
        [TestCase()]
        public void FuelAmountThrowsExceptionIfZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car testcar = new Car("123", "123", 4, 4);
                
            });
        }
        [Test]
        public void RefuelMethodWorksCorrectly()
        {
            Car testCar = new Car("123", "123", 4, 4);
            testCar.Refuel(5);
            Assert.AreEqual(testCar.FuelAmount, testCar.FuelCapacity);
        }
        [Test]
        public void RefuelMethodThrowsExceptionIfFuelIsZeroOrNegative()
        {
            Car testCar = new Car("123", "123", 4, 4);
            Assert.Throws<ArgumentException>(() =>
            {
                testCar.Refuel(-1);
            });

        }
        [Test]
        public void DriveMethodWorksCorrectly()
        {
            Car testCar = new Car("123", "123", 4, 4);
            testCar.Refuel(4);
            testCar.Drive(100);
            Assert.AreEqual(testCar.FuelAmount, 0);
        }
        [Test]
        public void DriveMethodThrowsExceptionIfNotEnoughFuel()
        {
            Car testCar = new Car("123", "123", 4, 4);
            testCar.Refuel(4);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testCar.Drive(101);
            });
        }
       
    }
}