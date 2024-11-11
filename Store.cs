using CarShopGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Tyler Benton
 * CST-250
 * Bradley Mauger
 * Activity 1
 * November 10, 2024 
 */

namespace CarShopGUI
{
    public class Store
    {
        public List<Car> CarList { get; set; }
        public List<Car> ShoppingList { get; set; }

        public Store()
        {
            // We must initialize each list or see the dreaded error: "Null reference not set to an instance of an object."
            CarList = new List<Car>();
            ShoppingList = new List<Car>();
        }

        public decimal checkout()
        {
            decimal totalCost = 0;

            // calculate the total cost of items in the cart.
            foreach (var c in ShoppingList)
            {
                totalCost += c.Price;
            }
            // clear the shopping cart
            ShoppingList.Clear();

            // return the total
            return totalCost;
        }
    }
}