using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            var vaultCells = new Dictionary<string, Item>
                 {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
        }

        [Test]
        public void ThrowsExceptionIfCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
           {
               string cell = "TestCell";
               Item item = new Item("TestOwner", "TestID");

               BankVault vault = new BankVault();
               vault.AddItem("asdf", item);

           });

        }
        [Test]
        public void CellIsTaken()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Dictionary<string, Item> vaultCells = 
                new Dictionary<string, Item> { { "A1", null } };

                vaultCells.Add("A1", null);
            });
        }
        [Test]
        public void CellExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                bool cellExists = this.vaultCells.Values
                      .Any(x => x?.ItemId == item.ItemId);
            });
         }
    }

}
    //public string AddItem(string cell, Item item)
    //{
    //    if (!this.vaultCells.ContainsKey(cell))
    //    {
    //        throw new ArgumentException("Cell doesn't exists!");
    //    }

    //    if (this.vaultCells[cell] != null)
    //    {
    //        throw new ArgumentException("Cell is already taken!");
    //    }

    //    bool cellExists = this.vaultCells.Values
    //        .Any(x => x?.ItemId == item.ItemId);

    //    if (cellExists)
    //    {
    //        throw new InvalidOperationException("Item is already in cell!");
    //    }

    //    this.vaultCells[cell] = item;

    //    return $"Item:{item.ItemId} saved successfully!";
}
