using System;
using System.Runtime.Serialization;

namespace Game.Actors
{
    [Serializable]
    internal class FullInventoryException : Exception
    {
        public FullInventoryException()
        {
        }

        public FullInventoryException(string message) : base(message)
        {
        }

        public FullInventoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FullInventoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}