using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchOrderPriority : Enumeration
    {
        // считаем, что сотрудник не может забирать заказ частично
        
        public static MerchOrderPriority Low = new(1, nameof(Low));
        public static MerchOrderPriority Medium = new(2, nameof(Medium));
        public static MerchOrderPriority High = new(3, nameof(High));
        public static MerchOrderPriority VeryHigh = new(10, nameof(VeryHigh));

        public MerchOrderPriority(int id, string name) : base(id, name) { }
    }
}