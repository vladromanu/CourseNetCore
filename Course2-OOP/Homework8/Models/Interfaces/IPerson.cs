using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8.Models.Interfaces
{
    interface IPerson
    {
        public string Name { get; }
        public Guid CustomerId { get; }

        public void WalkToStore(Store store);
    }
}
