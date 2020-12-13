using System;

namespace Destiny.Core.Flow.Exceptions
{
    public class AppException : Exception
    {



        public AppException()
        {

        }
        public AppException(string message) : base(message)
        {

        }
        public AppException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public AppException ThrowIf(bool flag)
        {
            if (flag)
            {
                throw this;
            }
            return this;
        }
    }
}
