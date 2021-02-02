
namespace Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using ExtendedDatabase;
    using System.ComponentModel;
    using NUnit.Framework.Internal;

    public class ExtendedDatabaseTests
    {
        ExtendedDatabase database;
        Person[] persons;
        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
            persons = new Person[16];
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Person[] data = new Person[16]
            {
                new Person(1234, "nikola") ,
                new Person(1235, "nikola1") ,
                new Person(1236, "nikola2") ,
                new Person(1237, "nikola3") ,
                new Person(1238, "nikola4") ,
                new Person(1239, "nikola5") ,
                new Person(1230, "nikola6") ,
                new Person(12311, "nikola7") ,
                new Person(123111, "nikola8") ,
                new Person(1231111, "nikola9") ,
                new Person(12311111, "nikola99") ,
                new Person(1232222, "nikola000") ,
                new Person(12322222, "nikola0") ,
                new Person(123222222, "nikola09") ,
                new Person(123333, "nikola788") ,
                new Person(1233333, "nikola678") ,
            };
            ExtendedDatabase database1 = new ExtendedDatabase(data);
            Assert.AreEqual(database1.Count, 16);
        }
        [Test]
        public void ConstructorThrowsExceptionIfLengthIsOver16()
        {
            Person[] data = new Person[17]
                 {
                new Person(1234, "nikola") ,
                new Person(1235, "nikola1") ,
                new Person(1236, "nikola2") ,
                new Person(1237, "nikola3") ,
                new Person(1238, "nikola4") ,
                new Person(1239, "nikola5") ,
                new Person(1230, "nikola6") ,
                new Person(12311, "nikola7") ,
                new Person(123111, "nikola8") ,
                new Person(1231111, "nikola9") ,
                new Person(12311111, "nikola99") ,
                new Person(1232222, "nikola000") ,
                new Person(12322222, "nikola0") ,
                new Person(123222222, "nikola09") ,
                new Person(123333, "nikola788") ,
                new Person(1233333, "nikola678") ,
                new Person(12333303, "nikola0678") ,
            };
            Assert.Throws<ArgumentException>(() =>
            {
                ExtendedDatabase database1 = new ExtendedDatabase(data);
            });

        }
        [Test]
        public void AddMethodWorksCorrectly()
        {
            database.Add(new Person(123, "nik"));
            Assert.AreEqual(database.Count, 1);
        }
        [Test]
        public void AddMethodThrowsExceptionIfInvalidCapacity()
        {
            Person[] data = new Person[16]
            {
                new Person(1234, "nikola") ,
                new Person(1235, "nikola1") ,
                new Person(1236, "nikola2") ,
                new Person(1237, "nikola3") ,
                new Person(1238, "nikola4") ,
                new Person(1239, "nikola5") ,
                new Person(1230, "nikola6") ,
                new Person(12311, "nikola7") ,
                new Person(123111, "nikola8") ,
                new Person(1231111, "nikola9") ,
                new Person(12311111, "nikola99") ,
                new Person(1232222, "nikola000") ,
                new Person(12322222, "nikola0") ,
                new Person(123222222, "nikola09") ,
                new Person(123333, "nikola788") ,
                new Person(1233333, "nikola678")
           };
            Assert.Throws<InvalidOperationException>(() =>
            {
                ExtendedDatabase database1 = new ExtendedDatabase(data);
                database1.Add(new Person(0123564, "niki123456"));
            });
        }
        [Test]
        public void AddMethodThrowsExceptionIfUsernameAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(123, "niki"));
                database.Add(new Person(1234, "niki"));
            });
        } 
        [Test]
        public void AddMethodThrowsExceptionIfIdAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(1234, "niki"));
                database.Add(new Person(1234, "niki123"));
            });
        }
        [Test]
        public void RemoveMethodWorksCorrectly()
        {
            database.Add(new Person(123, "niki"));
            database.Add(new Person(1234, "gogo"));
            database.Remove();
            Assert.AreEqual(database.Count, 1);
        }
        [Test]
        public void RemoveMethodThrowsExceptionIfCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void FindByUsernameWorksCorrectly()
        {
            Person testPerson = new Person(123, "niki");
            database.Add(testPerson);
            var foundPerson = database.FindByUsername("niki");
            Assert.AreSame(foundPerson, testPerson);
        }
        [Test]
        public void FindByUsernameThrowsExceptionIfInputIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var foundPerson = database.FindByUsername(null);
            });
        }
        [Test]
        public void FindByUsernameThrowsExceptionIfUserDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var foundPerson = database.FindByUsername("Nikiepi4");
            });
        }
        [Test]
        public void FindByIdWorksCorrectly()
        {
            Person testPerson = new Person(123, "niki");
            database.Add(testPerson);
            var foundPerson = database.FindById(123);
            Assert.AreSame(foundPerson, testPerson);
        }
        [Test]
        public void FindByIdThrowsExceptionIfIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            });
        } 
        [Test]
        public void FindByIdThrowsExceptionIfUserDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(123);
            });
        }
       
    }
}