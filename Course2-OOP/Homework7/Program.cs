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
                hotels = Randomizer.GenerateHotels(10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hotel Randomizer has failed. Msg <{ex.Message}>");
                return;
            }
    
            // 1. Add a hotel - Constructors 
            hotels.Add(new Hotel()
            {
                Name =  "Hotel X",
                City = Randomizer.RandomCity(),
                Rooms = new List<Room>()
                { 
                    new Room() { RoomTypeCode = Guid.NewGuid(), Name = "Double Standard", Adults = 2, Children = 0, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                    new Room() { RoomTypeCode = Guid.NewGuid(), Name = "Double Deluxe", Adults = 2, Children = 0, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                    new Room() { RoomTypeCode = Guid.NewGuid(), Name = "Triple Family Room", Adults = 3, Children = 2, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                    new Room() { RoomTypeCode = Guid.NewGuid(), Name = "King Suite", Adults = 2, Children = 2, Rate = new Rate(){ Amount = Randomizer.RandomAmout(), Currency=Currency.EUR} },
                }
            });
            PrintHotels(hotels);


            // 1.1. Add a hotel - object by object
            Hotel hotelY = new Hotel();
            hotelY.Name = "Hotel Y";
            hotelY.City = Randomizer.RandomCity();
            hotelY.Rooms = new List<Room>();

            Room roomY = new Room();
            roomY.RoomTypeCode = Guid.NewGuid();
            roomY.Name = "Double Standard";
            roomY.Adults = 2;
            roomY.Children = 0;
            roomY.Rate = new Rate();

            roomY.Rate.Amount = Randomizer.RandomAmout();
            roomY.Rate.Currency = Currency.EUR;
            
            hotelY.Rooms.Add(roomY);

            hotels.Add(hotelY);


            // 2. Delete a hotel - random index
            int indexToRemove = new Random().Next(0, hotels.Count);
            Console.WriteLine("================================================");
            Console.WriteLine($"List Size: {hotels.Count}");

            hotels.RemoveAt(indexToRemove);
            Console.WriteLine($"Removed random index <{indexToRemove}> from the hotels list");

            Console.WriteLine($"List Size: {hotels.Count}");
            Console.WriteLine("================================================\n");


            // 3. Find a room with a price lower than some value
            decimal valueToSearch = 400M;
            int numberOfDays = 2;

            Console.WriteLine("================================================");
            Console.WriteLine($"Rooms with price lower than <{valueToSearch}>");

            foreach (var hotel in hotels)
            {
                var RoomsFiltered = hotel.GetRoomsUnderValue(valueToSearch, numberOfDays);
                foreach (KeyValuePair<Guid, Rate> entry in RoomsFiltered)
                {
                    Console.WriteLine($"{hotel.Name} -> RoomTypeCode: {entry.Key}  Rate: {entry.Value}");
                }
            }
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