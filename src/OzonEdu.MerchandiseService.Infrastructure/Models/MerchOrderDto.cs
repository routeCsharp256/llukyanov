using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Models
{
    public class MerchOrderDto
    {
        public long Id { get; set; }

        public int EmployeeId { get; set; }

        public List<string> SkusRequested { get; set; }
        
        public List<Sku> SkusReserved { get; set; }

        public MerchPack MerchPack { get; set; }

        public MerchOrderStatus Status { get; set; }

        public MerchOrderPriority Priority { get; set; }

        public Date CreatedAt { get; set; }

        public Date ClosedAt { get; set; }
        
        public Date Deadline { get; set; }

        public int? ManagerId { get; set; }

        public bool IsEmployeeReceivedOrder { get; set; }
    }
}