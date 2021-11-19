using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    /// <summary>
    ///     Статус заказа. Считаем, что сотрудник не может забирать заказ частично
    /// </summary>
    public class MerchOrderStatus : Enumeration
    {
        
        public static MerchOrderStatus New = new(1, nameof(New));
        public static MerchOrderStatus Active = new(2, nameof(Active));
        public static MerchOrderStatus Closed = new(3, nameof(Closed));
        public static MerchOrderStatus Cancelled = new(10, nameof(Cancelled));

        public MerchOrderStatus(int id, string name) : base(id, name) { }
    }
}