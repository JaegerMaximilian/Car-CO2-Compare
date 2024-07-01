using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCO2Comparer_BullshitButton_MVP.Exceptions
{
    public class ValueBelowZeroException : Exception
    {
        public ValueBelowZeroException()
        {

        }

        public ValueBelowZeroException(string message) : base(message)
        {

        }
    }
}
