using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class RegexException : Exception
    {
        public RegexException(string message) : base(message)
        {
        }

        public RegexException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}