using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxAppLibrary;

namespace TaxAppTests
{
    [TestClass]
    public class ParserTests
    {
        [DataRow("1 book at £12.49",1,"book ", 12.49)]
        [DataRow("1 imported box of chocolates at £10.00", 1, "imported box of chocolates ", 10.00)]
        [DataRow("2 packets of headache pills at £9.75 ", 2, "packets of headache pills ", 9.75)]

        [TestMethod]
        public void InputParsingTest(string input, int expQty, string expName, Double price)
        {
            Decimal expPrice = Convert.ToDecimal(price);
            (int, string, decimal) exp = (expQty, expName, expPrice);

            (int, string, decimal) res = Parser.ParseItem(input);

            Assert.AreEqual(exp, res);

        }
    }
}
