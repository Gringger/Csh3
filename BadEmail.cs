using System;
using System.Runtime.Serialization;

namespace Lab03
{
    [Serializable]
    class BadEmail : Exception
    {
        public BadEmail() : base() { }

        public BadEmail(string message) : base(message) { }

        public BadEmail(string message, Exception inner) : base(message, inner) { }

        protected BadEmail(SerializationInfo info, StreamingContext context): base(info, context) { }
    }
}
