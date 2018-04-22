using System;
using System.Runtime.Serialization;

namespace Lab03
{
    [Serializable]
    class OverPastBirth : Exception
    {
        public OverPastBirth() : base() { }

        public OverPastBirth(string message) : base(message) { }

        public OverPastBirth(string message, Exception inner) : base(message, inner) { }

        protected OverPastBirth(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
