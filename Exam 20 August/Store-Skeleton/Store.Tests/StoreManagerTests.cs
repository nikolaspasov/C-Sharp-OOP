using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        StoreManager storeManager = new StoreManager();
        [SetUp]
        public void Setup()
        {
            storeManager = new StoreManager();
        }

        [Test]
        public void CountWorksCorrectly()
        {
            Product prod = new Product("test", 2, 10);
            Product prod1 = new Product("test", 2, 10);
            Product prod2= new Product("test", 2, 10);
            storeManager.AddProduct(prod);
            storeManager.AddProduct(prod1);
            storeManager.AddProduct(prod2);
            Assert.AreEqual(3, storeManager.Products.Count);
        }
        [Test]
        public void ThrowArgumentNullExceptionIfProductToAddIsNull()
        {
            Product prod = null;
            Assert.Throws<ArgumentNullException>(() => storeManager.AddProduct(prod));
        }
        [Test]
        public void ThrowArgumentExceptionIfProductToAddQuantityIsNotPositive()
        {
            Product prod = new Product("test", 0, 10);
            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(prod));
        }
        [Test]
        public void AddMethodWorksProperly()
        {
            Product prod = new Product("test", 10, 10);
            storeManager.AddProduct(prod);
            storeManager.AddProduct(prod);
            Assert.AreEqual(2, storeManager.Products.Count);
        }
        [Test]
        public void ThrowArgumentNullExceptionIfProductToBuyIsNull()
        {
            
            Assert.Throws<ArgumentNullException>(() => storeManager.BuyProduct("Nik",10));
        }
        [Test]
        public void ThrowArgumentExceptionIfProductToBuyQuantityIsInvalid()
        {
            Product prod = new Product("test", 4, 10);
            storeManager.AddProduct(prod);
            Assert.Throws<ArgumentException>(() => storeManager.BuyProduct("test",5));
        }
        [Test]
        public void FinalPriceIsCorrect()
        {
            Product prod = new Product("test", 10, 10);
            storeManager.AddProduct(prod);
            Assert.AreEqual(100, storeManager.BuyProduct("test", 10));
            Assert.AreEqual(0, prod.Quantity);
        }
        [Test]
        public void GetMostExpensiveProductWorksProperly()
        {
            Product prod1 = new Product("test1", 10, 12);
            Product prod2 = new Product("test2", 15, 100);
            Product prod3 = new Product("test3", 16, 1);

             storeManager.AddProduct(prod1);
            storeManager.AddProduct(prod2);
            storeManager.AddProduct(prod3);

            Assert.AreEqual(prod2, storeManager.GetTheMostExpensiveProduct());
        }
    }
}