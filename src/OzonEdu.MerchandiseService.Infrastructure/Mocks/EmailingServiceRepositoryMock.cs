using System;
using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks
{
    public class EmailingServiceRepositoryMock : IEmailingServiceRepository
    {
        public Task SendMailSingle(string email, string subject, string text, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}