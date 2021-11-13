using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    ///     Сотрудник прошёл испытательный срок
    /// </summary>
    public class ProbationPeriodEndedDomainEvent : INotification
    {
        public ProbationPeriodEndedDomainEvent()
        {
            EmployeeEventType = EmployeeEventType.ProbationPeriodEnding;
            MerchItems = new List<MerchItem>

            {
                new(
                    new Sku(1212),
                    new Name("Welcome to the Club twice!"),
                    new Item(MerchItemType.TShirt),
                    ClothingSize.M,
                    new Quantity(1)
                )
            };
        }

        public EmployeeEventType EmployeeEventType { get; }
        public List<MerchItem> MerchItems { get; }
    }
}