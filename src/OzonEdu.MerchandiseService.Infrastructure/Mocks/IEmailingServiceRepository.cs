using System.Collections.Generic;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks
{
    public interface IEmailingServiceRepository
    {
        Task SendMailSingle(string email, string subject, string text);
    }
}