using System;
using System.Collections.Generic;
using System.Linq;
using TaxAppLibrary.Models;

namespace TaxAppLibrary
{
    public class Calculator
    {
        public static Decimal CalculateProductTax(string name, Decimal price)
        {
            List<Tax> taxes = new List<Tax> { new BasicSalesTax(), new ImportTax() };
            return taxes.Sum(x => x.Calculate(name, price));
        }
    }
}
