using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItem : Entity
    {
        public MerchItem(
            Sku sku,
            Name name,
            Description description,
            MerchItemType itemType,
            HashSet<Tag> tags)
        {
            Sku = sku;
            Name = name;
            Description = description;
            ItemType = itemType;
            Tags = tags;
        }

        public Sku Sku { get; }
        public Name Name { get; }
        public Description Description { get; }
        public MerchItemType ItemType { get; }
        public HashSet<Tag> Tags { get; }
    }
}