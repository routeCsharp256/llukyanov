using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    /// <summary>
    ///     Статус заказа. Считаем, что сотрудник не может забирать заказ частично
    /// </summary>
    public class OrderStatus : Enumeration
    {
        public static OrderStatus New = new(1, nameof(New));
        public static OrderStatus Active = new(2, nameof(Active)); // заказ обрабатывается

        public static OrderStatus
            Prepared = new(3, nameof(Prepared)); // заказ полностью готов, ожидаем, когда сотрудник заберет его

        public static OrderStatus
            Closed = new(4,
                nameof(Closed)); // заказ завершён из-за того, что сотрудник взял все предназначенные ему мерч-итемы

        public static OrderStatus Cancelled = new(10, nameof(Cancelled)); // заказ отменён в ручном режиме

        public OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}