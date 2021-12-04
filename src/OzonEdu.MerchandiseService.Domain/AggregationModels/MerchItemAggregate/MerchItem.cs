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
            int itemTypeId,
            HashSet<Tag> tags)
        {
            Sku = sku;
            Name = name;
            Description = description;
            ItemTypeId = itemTypeId;
            Tags = tags;
        }

        public Sku Sku { get; }
        public Name Name { get; }
        public Description Description { get; }
        public int ItemTypeId { get; }
        public HashSet<Tag> Tags { get; }
    }
}