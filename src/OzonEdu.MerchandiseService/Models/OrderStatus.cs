namespace OzonEdu.MerchandiseService.Models
{
    public class OrderStatus
    {
        public Status Status { get; set; }
    }

    public enum Status
    {
        Draft = 0,
        Registered,
        Pending,
        Ready,
        Completed
    }
}