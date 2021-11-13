using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    /// <summary>
    ///     Сотрудник посетил конференцию в качестве спикера
    /// </summary>
    public class AttendedConferenceAsSpeakerDomainEvent : INotification
    {
        public AttendedConferenceAsSpeakerDomainEvent()
        {
            EmployeeEventType = EmployeeEventType.ConferenceAttendanceAsSpeaker;
            MerchItems = new List<MerchItem>
            {
                new(
                    new Sku(3333),
                    new Name("Лет ми спик фром"),
                    new Item(MerchItemType.Sweatshirt),
                    ClothingSize.XXL, // размер побольше, чтобы издалека было видно
                    new Quantity(1)
                )
            };
        }

        public EmployeeEventType EmployeeEventType { get; }
        public List<MerchItem> MerchItems { get; }
    }
}