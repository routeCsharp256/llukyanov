using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Models
{
    public class ConferenceDto
    {
        public IReadOnlyList<ConferenceMock> Conferences { get; set; }
    }
}