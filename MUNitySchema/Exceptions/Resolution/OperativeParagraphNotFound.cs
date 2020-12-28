using System;
using System.Collections.Generic;
using System.Text;

namespace MUNitySchema.Exceptions.Resolution
{

    /// <summary>
    /// Throw this exception when an operative section is not found inside the OperativeSection.
    /// </summary>
    [Serializable]
    public class OperativeParagraphNotFoundException : Exception
    {
        public OperativeParagraphNotFoundException() { }
        public OperativeParagraphNotFoundException(string message) : base(message) { }
        public OperativeParagraphNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected OperativeParagraphNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
