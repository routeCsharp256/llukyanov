using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks
{
    public class EmployeeServiceRepositoryMock : IEmployeeServiceRepository
    {
        public async Task<List<ConferenceMock>> GetAllConferences()
        {
            var result = new List<ConferenceMock>
            {
                new ConferenceMock
                {
                    Id = 1,
                    Date = Convert.ToDateTime("2020-01-02"),
                    Description = "this conference is passed",
                    Name = "conf#1"
                },
                new ConferenceMock
                {
                    Id = 2,
                    Date = Convert.ToDateTime("2022-01-02"),
                    Description = "that conference will be soon...",
                    Name = "conf#22"
                },
            };
            return result;
        }
    }
}