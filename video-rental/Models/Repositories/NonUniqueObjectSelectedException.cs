
using System;
namespace video_rental.Repositories
{
    public class NonUniqueObjectSelectedException : Exception
    {
        public NonUniqueObjectSelectedException()
        {
        }

        public NonUniqueObjectSelectedException(Exception cause) : base(cause.Message, cause)
        {

        }
    }
}
