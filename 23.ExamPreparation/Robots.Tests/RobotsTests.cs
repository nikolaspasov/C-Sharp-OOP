namespace Robots.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using NUnit.Framework;
    
    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        
        [SetUp]
        public void SetUp()
        {
            robot = new Robot("TestName", 10);
           
        }
        [Test]
        public void WhenRobotIsCreatedPropertiesShouldBeSet()
        {
            Assert.AreEqual("TestName", robot.Name);
            Assert.AreEqual(10, robot.Battery);
            Assert.AreEqual(10, robot.MaximumBattery);
        }

        [Test]
        public void ThrowExceptionIfRobotManagerCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-1);
            });
            
        }
        [Test]
        public void RobotIsCreatedCorrectly()
        {
            
                RobotManager manager = new RobotManager(2);
            manager.Add(robot);
            Assert.AreEqual(1, manager.Count);
             
            
        }
        [Test]
        public void ThrowExceptionIfRobotAlreadyExists()
        {
           Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager manager = new RobotManager(3);
                manager.Add(robot);
                Robot newRobot = new Robot("TestName", 10);
                manager.Add(newRobot);
            });
        }
        [Test]
        public void ThrowExceptionIfCapacityIsFull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager manager = new RobotManager(1);
                manager.Add(robot);
                manager.Add(new Robot("test2",12));
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager manager = new RobotManager(0);
                manager.Add(robot);
                
            });
            
        }
        [Test]
        public void WhenDataIsCorrectShouldWork()
        {
           
                RobotManager manager = new RobotManager(3);
                manager.Add(robot);
                manager.Add(new Robot("test2", 12));
            Assert.AreEqual(2, manager.Count);
            
            
        }
        [Test]
        public void ThrowExceptionIfRobotThatHasToBeRemovedDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager manager = new RobotManager(2);
                
                manager.Remove("NoRobot");
            });
           
        }
        [Test]
        public void RobotShouldBeRemovedCorrectly()
        {
            
                RobotManager manager = new RobotManager(2);
            manager.Add(new Robot("RemoveRob",4));
                manager.Remove("RemoveRob");
            Assert.AreEqual(0, manager.Count);
            
           
        }
        [Test]
        public void ThrowExceptionIfRobotThatHasToWorkDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager manager = new RobotManager(2);
                
                manager.Work("NoRobot","SomeJob",5);
            });
        }
         [Test]
        public void RobotShouldWorkCorrectly()
        {
            
                RobotManager manager = new RobotManager(2);
            
              Robot testRob =  new Robot("TestName", 10);
            manager.Add(testRob);
                manager.Work("TestName","SomeJob",5);
            Assert.That(testRob.Battery, Is.EqualTo(5));
           
        }

        [Test]
         public void ThrowExceptionIfRobotThatHasToWorkDoesNotHaveEnoughBattery()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager manager = new RobotManager(2);
                
                manager.Work("TestName","SomeJob",12);
            });
        }
        [Test]
        public void ThrowExceptionIfRobotToChargeDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                RobotManager manager = new RobotManager(2);
                
                manager.Charge("NoName");
            });
        } 
        [Test]
        public void RobotChargesCorrectly()
        {

            RobotManager manager = new RobotManager(2);

            Robot testRob = new Robot("TestName", 10);
            manager.Add(testRob);
            testRob.Battery = 5;
            manager.Charge("TestName");
            Assert.That(testRob.Battery, Is.EqualTo(testRob.MaximumBattery));

        }

       






    }
}

