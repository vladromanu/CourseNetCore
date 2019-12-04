using System;
using System.Collections.Generic;
using System.Text;

namespace Homework13
{
    class Clock : IClock
    {
        public DateTime Now => throw new NotImplementedException();

        public DateTime UtcNow => throw new NotImplementedException();

        public BusinessDate Today => throw new NotImplementedException();
    }
}
