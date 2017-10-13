using System;

namespace RGBSync
{
    class RGBSyncException : Exception
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
