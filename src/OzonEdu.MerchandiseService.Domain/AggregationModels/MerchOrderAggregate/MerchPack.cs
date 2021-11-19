using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchOrderAggregate
{
    public class MerchPack : Enumeration
    {
        public static MerchPack WelcomePack = new(10, nameof(WelcomePack));
        public static MerchPack ConferenceListenerPack = new(20, nameof(ConferenceListenerPack));
        public static MerchPack ConferenceSpeakerPack = new(30, nameof(ConferenceSpeakerPack));
        public static MerchPack ProbationPeriodEndingPack = new(40, nameof(ProbationPeriodEndingPack));
        public static MerchPack VeteranPack = new(50, nameof(VeteranPack));

        public MerchPack(int id, string name) : base(id, name) { }
    }
}