using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class NotFoundOrderException : Exception
    {
        public NotFoundOrderException() : base("Could not found Order")
        {
        }

        public NotFoundOrderException(string? message) : base(message)
        {
        }

        public NotFoundOrderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
