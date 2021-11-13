using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class EmployeeEventType : Enumeration
    {
        public static EmployeeEventType Hiring = new(1, nameof(Hiring));
        public static EmployeeEventType ProbationPeriodEnding = new(2, nameof(ProbationPeriodEnding));
        public static EmployeeEventType ConferenceAttendanceAsListener = new(3, nameof(ConferenceAttendanceAsListener));
        public static EmployeeEventType ConferenceAttendanceAsSpeaker = new(4, nameof(ConferenceAttendanceAsSpeaker));
        public static EmployeeEventType VeteranStatusEarning = new(5, nameof(VeteranStatusEarning));

        public EmployeeEventType(int id, string name) : base(id, name)
        {
        }
    }
}