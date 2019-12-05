using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Homework11
{
    [System.Serializable]
    public class InvalidRangeException<T> : System.Exception
    {
        private static readonly string DefaultMessage = "Invalid range exception";

        private T RangeMin { get; set; }
        private T RangeMax { get; set; }
        private T Element { get; set; }

        public InvalidRangeException(T min, T max, T element)
        {
            this.RangeMin = min ?? throw new ArgumentNullException(nameof(min));
            this.RangeMax = max ?? throw new ArgumentNullException(nameof(max));
            this.Element = element ?? throw new ArgumentNullException(nameof(element));
        }

        public override string Message { 
            get
            {
                return string.Format($"{DefaultMessage}.[Element {this.Element.ToString()} could not be inserted] Defined ranges are: {this.RangeMin.ToString()} - {this.RangeMax.ToString()} [TYPE: {typeof(T)}]");
            }
        }

        public InvalidRangeException() : base (DefaultMessage)
        {
        }

        protected InvalidRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidRangeException(string message) : base(message)
        {
        }

        public InvalidRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
