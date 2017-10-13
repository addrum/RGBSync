using System;

namespace RGBSync
{
    class RGBSetException : RGBSyncException
    {
        public RGBSetException()
        {
        }

        public RGBSetException(string message)
            : base(message)
        {
        }

        public RGBSetException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
