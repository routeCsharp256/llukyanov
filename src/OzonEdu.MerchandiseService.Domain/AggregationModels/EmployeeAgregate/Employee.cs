using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Employee : Entity
    {
        public Employee(
            int id,
            FullName fullName,
            Department department,
            Email email)
        {
            Id = id;
            FullName = fullName;
            Department = department;
            Email = email;
        }

        public int Id { get; }

        public FullName FullName { get; }

        public Department Department { get; }

        public Email Email { get; }
    }
}