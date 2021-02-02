using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void AddDriverWorksCorrectly()
        {
            var result = raceEntry.AddDriver(new UnitDriver("Name", new UnitCar("model", 123, 123)));
            Assert.AreEqual(raceEntry.Counter, 1);
            Assert.AreEqual(result, $"Driver Name added in race.");
        }
        [Test]
        public void AddDriverThrowsExceptionIfDriverIsNull()
        {
            UnitDriver ud = null;
            Assert.Throws<InvalidOperationException>(() =>
            { raceEntry.AddDriver(ud); });
        }
        [Test]
        public void AddDriverThrowsExceptionIfDriverAlreadyExists()
        {
            UnitDriver ud = new UnitDriver("Name", new UnitCar("model", 123, 123));
            raceEntry.AddDriver(ud);
            Assert.Throws<InvalidOperationException>(() =>
            { raceEntry.AddDriver(ud); });
        }
        [Test]
        public void CalculateAvgHorsePowerWorksCorrectly()
        {
            UnitDriver ud1= new UnitDriver("Name1", new UnitCar("model1", 100, 123));
            UnitDriver ud2 = new UnitDriver("Name2", new UnitCar("model2", 110, 123));
            raceEntry.AddDriver(ud1);
            raceEntry.AddDriver(ud2);
            var hp = raceEntry.CalculateAverageHorsePower();
            Assert.AreEqual(hp, 105);
        }
          [Test]
        public void CalculateAvgHorsePowerThrowsExceptionIfCountIsUnderMinParticipants()
        {
            UnitDriver ud1= new UnitDriver("Name1", new UnitCar("model1", 100, 123));
            raceEntry.AddDriver(ud1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                var hp = raceEntry.CalculateAverageHorsePower();
            });
        }


       

    }
}