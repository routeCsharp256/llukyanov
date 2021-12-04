using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class RegexNotMatchException : Exception
    {
        public RegexNotMatchException(string message) : base(message)
        {
        }

        public RegexNotMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}