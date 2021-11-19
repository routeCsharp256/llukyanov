using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Infrastructure.Models;

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