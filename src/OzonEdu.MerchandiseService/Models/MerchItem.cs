namespace OzonEdu.MerchandiseService.Models
{
    public class MerchItem
    {
        public MerchItem(long itemId, string itemName, int quantity)
        {
            ItemId = itemId;
            ItemName = itemName;
            Quantity = quantity;
        }

        public long ItemId { get; }

        public string ItemName { get; }

        public int Quantity { get; }
    }
}