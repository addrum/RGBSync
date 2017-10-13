using System;

namespace RGBSync
{
    class UninitializedException : RGBSyncException
    {
        public UninitializedException()
        {
        }

        public UninitializedException(string message)
            : base(message)
        {
        }

        public UninitializedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
