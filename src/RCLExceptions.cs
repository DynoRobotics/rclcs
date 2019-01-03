using System;

namespace rclcs
{
    public class RuntimeError : Exception
    {
        public RuntimeError()
        {
        }

        public RuntimeError(string message) : base(message)
        {
        }

        public RuntimeError(string message, Exception inner) : base(message, inner)
        {
        }
    }

    public class NotInitializedException : Exception
    {
        public NotInitializedException()
        {
        }

        public NotInitializedException(string message) : base(message)
        {
        }

        public NotInitializedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

