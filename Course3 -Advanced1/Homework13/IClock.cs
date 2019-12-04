using System;
using System.Collections.Generic;
using System.Text;

namespace Homework13
{
    public interface IClock
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        BusinessDate Today { get; }
    }
}
