using System;
using TaxAppLibrary.Models;

namespace TaxAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = new string[] { "1 book at £12.49", "1 music CD at £14.99", "1 chocolate bar at £0.85" };
            string[] input2 = new string[] { "1 imported box of chocolates at £10.00", "1 imported bottle of perfume at £47.50" };
            string[] input3 = new string[] { "1 imported bottle of perfume at £27.99", "1 bottle of perfume at £18.99", "1 packet of headache pills at £9.75", "1 box of imported chocolates at £11.25" };

            Basket b1 = new Basket(input1);
            b1.PrintReceipt();
            Console.WriteLine("---------------------------");

            Basket b2 = new Basket(input2);
            b2.PrintReceipt();
            Console.WriteLine("---------------------------");

            Basket b3 = new Basket(input3);
            b3.PrintReceipt();
            Console.WriteLine("---------------------------");

        }
    }
}
