using System;
using System.Runtime.Serialization;

namespace Lab03
{
    [Serializable]
    class FutureBirth: Exception
    {
        public FutureBirth() : base() { }

        public FutureBirth(string message) : base(message) { }

        public FutureBirth(string message, Exception inner) : base(message, inner) { }

        protected FutureBirth(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
