using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class ChangeStatusException : Exception
    {
        public ChangeStatusException(string message) : base(message)
        {
        }

        public ChangeStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}