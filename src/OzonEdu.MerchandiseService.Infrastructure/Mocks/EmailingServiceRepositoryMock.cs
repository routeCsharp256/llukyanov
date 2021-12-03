using System;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks
{
    public class EmailingServiceRepositoryMock : IEmailingServiceRepository
    {
        public Task SendMailSingle(string email, string subject, string text)
        {
            throw new NotImplementedException();
        }
    }
}