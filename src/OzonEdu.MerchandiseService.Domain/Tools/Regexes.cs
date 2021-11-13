using System.Text.RegularExpressions;

namespace OzonEdu.MerchandiseService.Domain.Tools
{
    public static class Regexes
    {
        public static readonly Regex OzonEmployeeEmailRegex = new(@"^\w{1,127}@ozon\.ru$", RegexOptions.IgnoreCase);
    }
}