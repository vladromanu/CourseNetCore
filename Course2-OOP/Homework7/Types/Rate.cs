using Homework7.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework7.Types
{
    class Rate
    {
        // Props + fields
        private decimal amount;
        private Currency currency;

        public decimal Amount { get => amount; set => amount = value; }
        public Currency Currency { get => currency; set => currency = value; }

        public Rate() : this(100M, Currency.EUR)
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
                return string.Format("Rate: {0:0.00} {1}", this.Amount, Enum.GetName(typeof(Currency), this.Currency)); 
            }
        }

        public override string ToString()
        {
            return this.Print;
        }
    }
}
