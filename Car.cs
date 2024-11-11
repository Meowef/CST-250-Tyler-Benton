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
    public class Car
    {
        // Existing properties
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        // New properties
        public int Year { get; set; }
        public string Color { get; set; }

        // Car Constructor with 5 parameters
        public Car(string make, string model, decimal price, int year, string color)
        {
            Make = make;
            Model = model;
            Price = price;
            Year = year;
            Color = color;
        }

        // Car const with 0 param, Provides default values.
        public Car()
        {
            Make = "Nothing yet";
            Model = "Nothing yet";
            Price = 0;
            Year = 0;  // Default value indicating unknown year
            Color = "None";  // Default value indicating no color assigned
        }

        public string Display
        {
            get
            {
                return string.Format("{0} {1} {2} {3} ${4}", Make, Model, Year, Color, Price);
            }
        }
    }
}
