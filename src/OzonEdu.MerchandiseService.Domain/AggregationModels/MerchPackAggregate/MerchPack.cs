using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public class MerchPack : Entity
    {
        public MerchPack(
            int id,
            Name name,
            int employeeEventId,
            bool isConference,
            List<Sku> skusRequested)
        {
            Id = id;
            Name = name;
            EmployeeEventId = employeeEventId;
            IsConference = isConference;
            SkusRequested = skusRequested;
        }

        public int Id { get; }

        public Name Name { get; }

        public int EmployeeEventId { get; }

        public bool IsConference { get; }

        public IReadOnlyList<Sku> SkusRequested { get; } = new List<Sku>();
    }
}