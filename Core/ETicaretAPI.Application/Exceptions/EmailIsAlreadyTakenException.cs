using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class EmailIsAlreadyTakenException : Exception
    {
        public EmailIsAlreadyTakenException() : base("Email Is Already Taken")
        {
        }

        public EmailIsAlreadyTakenException(string? message) : base(message)
        {
        }

        public EmailIsAlreadyTakenException(string? message, Exception? innerException) : base(message, innerException)
        {
        }


    }
}
