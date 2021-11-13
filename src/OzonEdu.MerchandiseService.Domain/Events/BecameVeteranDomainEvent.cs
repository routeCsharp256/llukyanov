using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    ///     Сотрудник проработал в компании N лет
    /// </summary>
    public class BecameVeteranDomainEvent : INotification
    {
        public BecameVeteranDomainEvent()
        {
            EmployeeEventType = EmployeeEventType.VeteranStatusEarning;
            MerchItems = new List<MerchItem>
            {
                new(
                    new Sku(1965),
                    new Name("Вещмешок"),
                    new Description("Dolor"),
                    new Item(MerchItemType.Bag),
                    null,
                    new Quantity()
                )
            };
        }

        public EmployeeEventType EmployeeEventType { get; }
        public List<MerchItem> MerchItems { get; }
    }
}