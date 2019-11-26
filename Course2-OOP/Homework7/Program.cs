using Homework7.Enums;
using Homework7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hotel> hotels;

            try
            {
                hotels = Randomizer.GenerateHotels(15);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hotel Randomizer has failed. Msg <{ex.Message}>");
                return;
            }
    
            // Add a hotel 
            hotels.Add(new Hotel()
            {
                Name =  "Hotel X",
                City = Randomizer.RandomCity(),
                Rooms = new List<Room>()
                { 
                    new Room() { Name = "Double Standard", Adults = 2, Children = 0, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                    new Room() { Name = "Double Deluxe", Adults = 2, Children = 0, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                    new Room() { Name = "Triple Family Room", Adults = 3, Children = 2, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                    new Room() { Name = "King Suite", Adults = 2, Children = 2, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                }
            });
            PrintHotels(hotels);

            // Delete a hotel
            hotels.RemoveAt(2);
            PrintHotels(hotels);

            // Find a room with a price lower than some value
            //List<Hotel>  = list.FindAll(x => (x % 2) == 0);

            Console.WriteLine("Hello World!");
        }

        public static void PrintHotels(List<Hotel> hotels)
        {
            foreach (Hotel hotel in hotels)
            {
                Console.WriteLine(hotel.Print);
            }
        }

    }
}
