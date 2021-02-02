namespace Tests
{
    using Database;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    public class DatabaseTests
    {
        Database database;
        int[] testData;
        [SetUp]
        public void Setup()
        {
            testData = new int[16]
            { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,13, 14, 15, 16 };
            database = new Database();
        }

        [Test]
        public void ConstructorWorksProperly()
        {

            for (int i = 0; i < testData.Length; i++)
            {
                database.Add(testData[i]);
            }

            Assert.AreEqual(testData.Length, database.Count);

        }
        [Test]
        public void AddWorksCorrectly()
        {
            int element = 100;

            database.Add(element);
            database.Add(element);

            Assert.AreEqual(2, database.Count);

        }
        [Test]
        public void AddMethodThrowsExceptionIfCapacityIsReached()
        {
            int element = 100;

            for (int i = 0; i < testData.Length; i++)
            {
                database.Add(testData[i]);
            }

            Assert.Throws<InvalidOperationException>(() =>
            { database.Add(element);});

        }
        [Test]
        public void RemoveWorksCorrectly()
        {

            for (int i = 0; i < testData.Length; i++)
            {
                database.Add(testData[i]);
            }
            database.Remove();
            Assert.AreEqual(database.Count, 15);
        }
         [Test]
        public void RemoveMethodThrowsExceptionIfCollectionIsEmpty()
        {

            Assert.Throws<InvalidOperationException>(() =>
            { database.Remove(); });
        }
         [Test]
        public void FetchWorksCorrectly()
        {
            for (int i = 0; i < testData.Length; i++)
            {
                database.Add(testData[i]);
            }


          var copyArray = database.Fetch();
            Assert.AreEqual(testData, copyArray);
        }

       


    }

}