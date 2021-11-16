using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Events;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItem : Entity
    {
        public MerchItem(Sku sku,
            Name name,
            Description description,
            Item itemType,
            ClothingSize size,
            Quantity quantity)
        {
            Sku = sku;
            Name = name;
            Description = description;
            ItemType = itemType;
            Quantity = quantity;
            SetClothingSize(size);
        }

        public Sku Sku { get; }
        public Name Name { get; }
        public Description Description { get; }
        public Item ItemType { get; }
        public ClothingSize ClothingSize { get; private set; }
        public Quantity Quantity { get; }

        public Tag Tag { get; set; }


        private void SetClothingSize(ClothingSize size)
        {
            if (size is not null && ItemType.IsClothes)
                ClothingSize = size;
            else if (size is null && !ItemType.IsClothes)
                ClothingSize = null;

            else if (size is null && ItemType.IsClothes)
                throw new ArgumentException($"Merch item with type {ItemType.Type.Name} must have size");
            else
                throw new ArgumentException($"Merch item with type {ItemType.Type.Name} cannot get size");
        }

        private void AddMerchItemsReceivedDomainEvent(Sku sku, Quantity quantity)
        {
            var merchReceivedDomainEvent = new MerchItemsReceivedDomainEvent(sku, quantity);
        
            this.AddDomainEvent(merchReceivedDomainEvent);
        }

        private void AddMerchItemsReservedDomainEvent(Sku sku, Quantity quantity)
        {
            var merchReservedDomainEvent = new MerchItemsReservedDomainEvent(sku, quantity);
        
            this.AddDomainEvent(merchReservedDomainEvent);
        }
    }
}