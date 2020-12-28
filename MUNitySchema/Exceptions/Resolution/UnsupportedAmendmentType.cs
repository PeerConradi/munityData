using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Exceptions.Resolution
{

    /// <summary>
    /// Throw this Exception when the given implementation of the AbstractAmendment is not capable to work with 
    /// in a given case.
    /// </summary>
    [Serializable]
    public class UnsupportedAmendmentTypeException : Exception
    {
        public UnsupportedAmendmentTypeException() { }
        public UnsupportedAmendmentTypeException(string message) : base(message) { }
        public UnsupportedAmendmentTypeException(string message, Exception inner) : base(message, inner) { }
        protected UnsupportedAmendmentTypeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
