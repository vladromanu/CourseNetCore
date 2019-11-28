using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class Producer : IProducer
    {
        private string name;
        private Guid producerId;

        public string Name { get => this.name; }
        public Guid ProducerId { get => this.producerId; }

        public Producer(string name, Guid producerId)
        {
            this.name = name;
            this.producerId = producerId;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}