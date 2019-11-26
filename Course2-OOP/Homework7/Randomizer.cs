using Homework7.Enums;
using Homework7.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7
{
    class Randomizer
    {
        public static decimal RandomAmout()
        {
            var rand = new Random();
            return new decimal(rand.NextDouble() + rand.Next(100,400));
        }

        public static string RandomString(int size = 10)
        {
            StringBuilder builder = new StringBuilder();

            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * new Random().NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public static string RandomCity()
        {
            Array values = Enum.GetValues(typeof(City));
            Random random = new Random();

            return Enum.GetName(typeof(City), values.GetValue(random.Next(values.Length)));
        }

        public static string RandomCurrency()
        {
            Array values = Enum.GetValues(typeof(Currency));
            Random random = new Random();

            return Enum.GetName(typeof(Currency), values.GetValue(random.Next(values.Length)));
        }

        public static List<Hotel> GenerateHotels(int number = 5)
        {
            List<Hotel> hotels = new List<Hotel>();

            for (int i = 0; i < number; i++)
            {
                hotels.Add(new Hotel()
                {
                    Name = $"Hotel {i}",
                    City = Randomizer.RandomCity(),
                    Rooms = new List<Room>()
                });
            }

            return hotels;
        }

    }
}
