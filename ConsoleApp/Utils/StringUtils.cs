namespace ConsoleApp.Utils
{
    using System.Xml.Linq;
    using System;

    public static class StringUtils
    {
        public static string TrimAndReplaceNewLine(this string source)
        {
            if (source != null)
            {
                return source.Trim().Replace(" ", "").Replace(Environment.NewLine, "");
            }

            return source;
        }

        public static bool EqualsIgnoreCase(this string source, string target)
        {
            if (source != null && target != null)
            {
                return source.ToUpper() == target.ToUpper();
            }

            return false;
        }
    }
}
