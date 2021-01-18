using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TaxAppLibrary
{
    public class Parser
    {
        public static (int qty, string name, Decimal price) ParseItem(string item)
        {
            //1 imported bottle of perfume at £47.50
            string InputPattern = "(\\d+) ([\\w\\s]* )at £(\\d+.\\d{2})";
            Regex rx = new Regex(InputPattern);
            Match m = rx.Match(item);
            if (m.Success)
            {
                int qty = Convert.ToInt32(m.Groups[1].Value);
                string name = m.Groups[2].Value;
                Decimal price = Convert.ToDecimal(m.Groups[3].Value);
                return (qty, name, price);
            }
            else return (0, "", 0);
        }
    }
}
