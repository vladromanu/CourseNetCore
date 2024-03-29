﻿namespace Homework12.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Address Address { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public Company Company { get; set; }

        public override string ToString()
        {
            return new string($"User[{this.Id}] {this.Name} -- email: {this.Email}");
        }
    }
}
