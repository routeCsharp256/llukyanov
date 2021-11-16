using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Domain.Events
{
    // мерч с таким-то SKU в таком-то кол-ве зарезервирован для выдачи сотруднику
    public class MerchItemsReservedDomainEvent : INotification
    {
        public Sku Sku { get; }
        public Quantity Quantity { get; }
        
        public MerchItemsReservedDomainEvent(Sku sku, Quantity quantity)
        {
            Sku = sku;
            Quantity = quantity;
        }
    }
}