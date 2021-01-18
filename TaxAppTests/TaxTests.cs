using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxAppLibrary;
using TaxAppLibrary.Models;

namespace TaxAppTests
{
    [TestClass]
    public class TaxTests
    {
        [TestMethod]
        [DataRow("1 book ", 12.49, 0, DisplayName="No Basic Sales Tax")]
        [DataRow("1 music CD  ", 14.99, 1.5, DisplayName = "Basic Sales Tax")]
        [DataRow("1 imported bottle of perfume", 47.50, 4.75, DisplayName ="Basic Sales Tax No Import")]
        public void BasicSalesTaxCalculation(string name, Double p, Double e)
        {
            Decimal price = Convert.ToDecimal(p);
            Decimal expTax = Convert.ToDecimal(e);
            BasicSalesTax bst = new BasicSalesTax();

            Decimal tax = bst.Calculate(name, price);

            Assert.AreEqual(expTax, tax);
        }

        [TestMethod]
        [DataRow("1 book ", 12.49, 0, DisplayName = "No Import Tax")]
        [DataRow("1 imported bottle of perfume", 47.50, 2.4, DisplayName = "Import Tax")]
        public void ImportTaxCalculation(string name, Double p, Double e)
        {
            Decimal price = Convert.ToDecimal(p);
            Decimal expTax = Convert.ToDecimal(e);
            ImportTax bst = new ImportTax();

            Decimal tax = bst.Calculate(name, price);

            Assert.AreEqual(expTax, tax);
        }

        [DataRow("1 book ", 12.49, 0, DisplayName = "No Taxes")]
        [DataRow("1 imported bottle of perfume", 47.50, 7.15, DisplayName = "BST and Import")]
        [DataRow("1 imported box of chocolates", 10.00, 0.5, DisplayName = "Import Tax")]
        [DataRow("1 bottle of perfume", 18.99, 1.9, DisplayName = "Basic Sales Tax")]

        [TestMethod]
        public void ProductTaxCalculation(string name, Double p, Double e)
        {
            Decimal price = Convert.ToDecimal(p);
            Decimal expTax = Convert.ToDecimal(e);

            Decimal prodTax = Calculator.CalculateProductTax(name, price);

            Assert.AreEqual(expTax, prodTax);
        }

        [DataRow(1, "book", 12.49, 0, DisplayName = "NO Tax")]
        [DataRow(1, "music CD", 14.99, 1.5, DisplayName = "BST Tax")]
        [DataRow(1, "imported box of chocolates", 10.00, 0.5, DisplayName="Import Tax")]
        [DataRow(1, "imported bottle of perfume", 47.50, 7.15, DisplayName = "BST and Import")]
        [DataRow(2, "imported bottles of perfume", 47.50, 14.3, DisplayName = "Quantity")]

        [TestMethod]
        public void ItemTaxCalculation(int qty, string name, Double p, Double e)
        {
            Decimal price = Convert.ToDecimal(p);
            Decimal expTax = Convert.ToDecimal(e);

            BasketItem item = new BasketItem() { Quantity = qty, Name = name, BasePrice = price };

            Assert.AreEqual(expTax, item.Tax);
        }

        [DataRow(1, "book", 12.49, 12.49, DisplayName = "NO Tax")]
        [DataRow(1, "music CD", 14.99, 16.49, DisplayName = "BST Tax")]
        [DataRow(1, "imported box of chocolates", 10.00, 10.5, DisplayName = "Import Tax")]
        [DataRow(1, "imported bottle of perfume", 47.50, 54.65, DisplayName = "BST and Import")]
        [DataRow(2, "imported bottles of perfume", 47.50, 109.3, DisplayName = "Quantity")]
        [TestMethod]
        public void ItemCostCalculation(int qty, string name, Double p, Double e)
        {
            Decimal price = Convert.ToDecimal(p);
            Decimal expCost = Convert.ToDecimal(e);

            BasketItem item = new BasketItem() { Quantity = qty, Name = name, BasePrice = price };

            Assert.AreEqual(expCost, item.Cost);
        }
    }
}
