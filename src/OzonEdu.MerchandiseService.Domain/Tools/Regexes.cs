using System.Text.RegularExpressions;

namespace OzonEdu.MerchandiseService.Domain.Tools
{
    public static class Regexes
    {
        public static readonly Regex OzonEmployeeEmailRegex =
            new(@"^[a-z0-9_-]{1,127}@ozon\.ru$", RegexOptions.IgnoreCase);
    }
}