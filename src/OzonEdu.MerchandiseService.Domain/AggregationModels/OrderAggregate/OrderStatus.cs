using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.OrderAggregate
{
    /// <summary>
    ///     Статус заказа. Считаем, что сотрудник не может забирать заказ частично
    /// </summary>
    public class OrderStatus : Enumeration
    {
        public static OrderStatus New = new(1, nameof(New));
        /// <summary>
        /// заказ обрабатывается
        /// </summary>
        public static OrderStatus Active = new(2, nameof(Active));

        /// <summary>
        /// заказ полностью готов, ожидаем, когда сотрудник заберет его
        /// </summary>
        public static OrderStatus Prepared = new(3, nameof(Prepared));

        /// <summary>
        /// заказ завершён из-за того, что сотрудник взял все предназначенные ему мерч-итемы
        /// </summary>
        public static OrderStatus Closed = new(4, nameof(Closed));

        /// <summary>
        /// заказ отменён в ручном режиме
        /// </summary>
        public static OrderStatus Cancelled = new(10, nameof(Cancelled));

        public OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}