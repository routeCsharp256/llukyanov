using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    ///     Сотрудник посетил конференцию в качестве слушателя
    /// </summary>
    public class AttendedConferenceAsListenerDomainEvent : INotification
    {
        public AttendedConferenceAsListenerDomainEvent()
        {
            EmployeeEventType = EmployeeEventType.ConferenceAttendanceAsListener;
            MerchItems = new List<MerchItem>
            {
                new(
                    new Sku(124),
                    new Name("Спать нельзя записывать"),
                    new Description("Lorem"),
                    new Item(MerchItemType.Notepad),
                    null,
                    new Quantity()
                )
            };
        }

        public EmployeeEventType EmployeeEventType { get; }
        public List<MerchItem> MerchItems { get; }
    }
}