using Homework8.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models
{
    class Producer : IProducer
    {
        public string Name { get; set; }
        public Guid ProducerId { get; set; }
    }
}
