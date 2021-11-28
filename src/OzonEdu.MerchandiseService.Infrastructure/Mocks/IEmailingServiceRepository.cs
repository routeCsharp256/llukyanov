using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks
{
    public interface IEmailingServiceRepository
    {
        Task SendMailSingle(string email, string subject, string text);
    }
}