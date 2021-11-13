using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    ///     Сотрудник нанят в компанию
    /// </summary>
    public class HiredDomainEvent : INotification
    {
        public HiredDomainEvent()
        {
            EmployeeEventType = EmployeeEventType.Hiring;
            MerchItems = new List<MerchItem>
            {
                new(
                    new Sku(12342),
                    new Name("Welcome to the Club!"),
                    new Description("Описание"),
                    new Item(MerchItemType.TShirt),
                    ClothingSize.M,
                    new Quantity()
                )
            };
        }

        public EmployeeEventType EmployeeEventType { get; }
        public List<MerchItem> MerchItems { get; }
    }
}