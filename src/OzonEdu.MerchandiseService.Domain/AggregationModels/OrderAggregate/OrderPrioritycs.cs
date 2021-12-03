using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    public class OrderPriority : Enumeration
    {
        // считаем, что сотрудник не может забирать заказ частично

        public static OrderPriority Low = new(1, nameof(Low));
        public static OrderPriority Medium = new(2, nameof(Medium));
        public static OrderPriority High = new(3, nameof(High));
        public static OrderPriority Critical = new(10, nameof(Critical));

        public OrderPriority(int id, string name) : base(id, name)
        {
        }
    }
}