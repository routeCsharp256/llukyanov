using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class EmployeeEvent : Entity
    {
        public EmployeeEvent(EmployeeEventType employeeEventType)
        {
            EmployeeEventType = employeeEventType;
        }

        public EmployeeEventType EmployeeEventType { get; }
    }
}