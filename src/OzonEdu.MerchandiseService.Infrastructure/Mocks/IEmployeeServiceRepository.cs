using System.Collections.Generic;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Infrastructure.Models;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Mocks
{
    public interface IEmployeeServiceRepository
    {
        Task<List<ConferenceMock>> GetAllConferences();
    }
}