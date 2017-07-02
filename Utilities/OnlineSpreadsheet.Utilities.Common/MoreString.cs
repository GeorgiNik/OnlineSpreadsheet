namespace OnlineSpreadsheet.Utilities.Common
{
    using System;
    using System.Text.RegularExpressions;
    using OnlineSpreadsheet.Localization.Resources;
    using Newtonsoft.Json;

    public static class MoreString
    {
        public static string ToJson(this object obj)
        {
            var res = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return res;
        }

        public static string GetTranslation(this string str)
        {
            try
            {
                var translation = Resources.ResourceManager.GetString(str);
                if (string.IsNullOrWhiteSpace(translation))
                {
                    translation = str;
                }

                return translation;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string Truncate(this string str, int characters)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }

            if (str.Length > characters)
            {
                str = str.Substring(0, characters);
                str += "...";
            }

            return str;
        }

        public static string PascalCaseToSentence(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {char.ToLower(m.Value[1])}");
        }

        public static string DateOnly(this DateTime str) => str.ToString("d/M/yyyy");

        public static string DateOnly(this DateTime? str) => str?.ToString("d/M/yyyy");

        public static string JoinWithHyphen(this string text)
        {
            return text.ToLower().Replace(" ", "-");
        }
    }
}