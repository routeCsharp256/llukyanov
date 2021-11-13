using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItem : Entity
    {
        public MerchItem(Sku sku,
            Name name,
            Item itemType,
            ClothingSize size,
            Quantity quantity)
        {
            Sku = sku;
            Name = name;
            ItemType = itemType;
            SetClothingSize(size);
            SetQuantity(quantity);
        }

        public Sku Sku { get; }

        public Name Name { get; }

        public Item ItemType { get; }

        public ClothingSize ClothingSize { get; private set; }

        public Quantity Quantity { get; private set; }


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

        private void SetQuantity(Quantity value)
        {
            if (value.Value < 0)
                throw new NegativeValueException($"Merch item Quantity value is negative: {nameof(value)}");

            Quantity = value;
        }
    }
}