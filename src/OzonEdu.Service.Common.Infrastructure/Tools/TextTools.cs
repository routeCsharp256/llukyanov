namespace OzonEdu.Service.Common.Infrastructure.Tools
{
    public static class TextTools
    {
        public static string RemoveWhitespaces(string text)
        {
            if (text is null)
                return "";

            var charactersToReplace = new[] {"\t", "\r\n", "\n", "\r", " "};
            foreach (var c in charactersToReplace)
                text = text.Replace(c, "");

            return text;
        }
    }
}