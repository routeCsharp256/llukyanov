using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class Department : ValueObject
    {
        public Department(string department)
        {
            Value = department;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}