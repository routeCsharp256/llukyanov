using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    public class OrderPreparedDomainEvent : INotification
    {
        public OrderPreparedDomainEvent(Email employeeEmail)
        {
            EmployeeEmail = employeeEmail;
        }

        public Email EmployeeEmail { get; }
    }
}