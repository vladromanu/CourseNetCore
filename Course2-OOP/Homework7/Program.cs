using Homework7.Enums;
using Homework7.Types;
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

            // 0. Randomize hotels
            try
            {
                hotels = Randomizer.GenerateHotels(15);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hotel Randomizer has failed. Msg <{ex.Message}>");
                return;
            }
    
            // 1. Add a hotel 
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


            // 2. Delete a hotel
            int indexToRemove = new Random().Next(0, hotels.Count);
            hotels.RemoveAt(indexToRemove);
            Console.WriteLine($"Removed random index <{indexToRemove}> from the hotels list");

            Console.WriteLine("New Hotel List is: ");
            PrintHotels(hotels);


            // 3. Find a room with a price lower than some value
            decimal valueToSearch = 150M;
            List<Hotel> hotelsFound = hotels.FindAll(x => x.GetPriceForNumberOfRooms(1) < valueToSearch);

            Console.WriteLine($"Hotels with rooms lower than {valueToSearch}");
            PrintHotels(hotelsFound);

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
