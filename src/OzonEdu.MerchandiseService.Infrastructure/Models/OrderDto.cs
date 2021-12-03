using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Models
{
    public class OrderDto
    {
        public long Id { get; set; }

        public string EmployeeEmail { get; set; }

        public List<long> SkusRequested { get; set; } = new();

        public List<long> SkusReserved { get; set; } = new();

        public int? MerchPackId { get; set; }

        public int StatusId { get; set; }

        public int PriorityId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ClosedAt { get; set; }

        public DateTime? Deadline { get; set; }

        public int? ManagerId { get; set; }

        public bool IsEmployeeReceivedOrder { get; set; }
    }
}