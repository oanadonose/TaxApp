using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxAppLibrary.Models
{
    public class Basket
    {
        public List<BasketItem> BasketItems { get; set; }
        public Decimal CalculateSalesTaxes(List<BasketItem> basketItems)
        {
            return basketItems.Sum(x => x.Tax);
        }
        public Decimal CalculateTotal(List<BasketItem> basketItems)
        {
            return basketItems.Sum(x => x.Cost);
        }
        public Basket(string[] items)
        {
            BasketItems = new List<BasketItem>();
            foreach (string item in items)
            {
                //parses item to return qty, name, price
                (int qty, string name, decimal price) = Parser.ParseItem(item);
                BasketItem i = new BasketItem() { Quantity = qty, Name = name, BasePrice = price };
                BasketItems.Add(i);
            }
        }
        public void PrintReceipt()
        {
            foreach(BasketItem item in BasketItems)
            {
                Console.WriteLine($"{item.Quantity} {item.Name}: £{item.Cost}");
            }
            Decimal taxes = CalculateSalesTaxes(BasketItems);
            Decimal total = CalculateTotal(BasketItems);
            Console.WriteLine("Sales Taxes: £" + taxes);
            Console.WriteLine("Total: £" + total);
        }
    }
}
