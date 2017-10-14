using System;

namespace RGBSync
{
    public class RGBSyncException : Exception
    {
        public RGBSyncException()
        {
        }

        public RGBSyncException(string message)
            : base(message)
        {
        }

        public RGBSyncException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
