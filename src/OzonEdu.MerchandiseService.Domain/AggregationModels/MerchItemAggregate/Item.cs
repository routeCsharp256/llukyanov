using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Item : Entity
    {
        public Item(MerchItemType type, bool isClothes = false)
        {
            Type = type;
            IsClothes = isClothes;
        }

        public MerchItemType Type { get; }

        public bool IsClothes { get; } // TODO: Is that field needed?
    }
}