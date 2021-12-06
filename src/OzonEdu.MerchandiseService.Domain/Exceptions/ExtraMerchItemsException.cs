using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class ExtraMerchItemsException : Exception
    {
        public ExtraMerchItemsException(string message) : base(message)
        {
        }

        public ExtraMerchItemsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}