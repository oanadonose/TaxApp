using System;
using System.Collections.Generic;
using System.Text;

namespace TaxAppLibrary.Models
{
    public class BasketItem : IProduct
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public Decimal BasePrice { get; set; }

        public Decimal Tax { get { return Quantity * Calculator.CalculateProductTax(Name, BasePrice); } }

        public Decimal Cost { get { return Quantity * BasePrice + Tax; } }

    }
}
