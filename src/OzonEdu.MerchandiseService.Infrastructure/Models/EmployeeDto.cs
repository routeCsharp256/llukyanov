namespace OzonEdu.MerchandiseService.Infrastructure.Models
{
    public class EmployeeNotificatoionDto
    {
        public long OrderId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string MerchPack { get; set; }
    }
}