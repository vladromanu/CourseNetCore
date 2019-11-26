using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7.Models
{
    class Rate
    {
        private decimal amount;
        private Currency currency;

        public decimal Amount { get => amount; set => amount = value; }
        public Currency Currency { get => currency; set => currency = value; }

        public Rate() : this(100, Currency.EUR)
        {
        }

        public Rate( decimal _amount, Currency _currency)
        {
            this.Amount = _amount;
            this.Currency = _currency;
        }

        public string Print
        {
            get
            {
                return $"{Amount} {Enum.GetName(typeof(Currency), Currency)}";
            }
        }

        public override string ToString()
        {
            return this.Print;
        }
    }
}
