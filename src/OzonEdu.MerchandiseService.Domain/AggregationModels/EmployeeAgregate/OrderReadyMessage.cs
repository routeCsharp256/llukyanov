namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public class OrderReadyMessage
    {
        public string Email { get; set; }
        
        public string Subject { get; set; }
        
        public string Text { get; set; }
    }
}