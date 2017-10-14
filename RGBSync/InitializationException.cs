using System;

namespace RGBSync
{
    public class InitializationException : RGBSyncException
    {
        public InitializationException()
        {
        }

        public InitializationException(string message)
            : base(message)
        {
        }

        public InitializationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
