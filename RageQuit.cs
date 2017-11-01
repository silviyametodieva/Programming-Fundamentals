using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrders
{
    class CoffeeOrders
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal tottalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                decimal price= ReadOrderAndCalculatePrice();
                tottalPrice += price;
            }
            Console.WriteLine($"Total: ${tottalPrice:f2}");

        }

        static decimal ReadOrderAndCalculatePrice()
        {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            string dateStr = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateStr,"d/M/yyyy",null);
            decimal daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            decimal capsules = decimal.Parse(Console.ReadLine());

            decimal price = daysInMonth * capsules * pricePerCapsule;

            Console.WriteLine($"The price for the coffee is: ${price:f2}");

            return price;
        }
    }
}
