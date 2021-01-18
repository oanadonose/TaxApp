using System;

namespace TaxAppLibrary.Models
{
    public abstract class Tax
    {
        public abstract Decimal Rate { get; }
        public abstract bool IsApplicable(string name);

        public Decimal Calculate(string name, Decimal price)
        {
            Decimal tax = price * Rate;
            if (IsApplicable(name)) return Math.Ceiling(tax * 20) / 20;
            else return 0.00m;
        }
    }
    public class BasicSalesTax : Tax
    {
        public override Decimal Rate { get { return 0.1m; } }
        public override bool IsApplicable(string name)
        {
            string[] BSTExceptions = new string[] { "book", "chocolate", "pill" };
            foreach(string exc in BSTExceptions)
            {
                if (name.Contains(exc)) return false;
            }
            return true;

        }
    }
    public class ImportTax : Tax
    {
        public override Decimal Rate { get { return 0.05m; } }
        public override bool IsApplicable(string name)
        {
            if (name.Contains("imported")) return true;
            return false;
        }
    }

}
