namespace OnlineSpreadsheet.Utilities.Common
{
    using System;
    using System.Collections.Generic;
    using OnlineSpreadsheet.Localization.Resources;

    public static class MoreEnumeration
    {
        public static IEnumerable<EnumerationItemVM> EnumToList<T>()
        {
            var list = new List<EnumerationItemVM>();

            foreach (var value in Enum.GetValues(typeof(T)))
            {
                string name = Resources.ResourceManager.GetString(Enum.GetName(typeof(T), (int)value));

                if (string.IsNullOrEmpty(name))
                {
                    name = Enum.GetName(typeof(T), (int)value);
                }

                list.Add(new EnumerationItemVM((int)value, name));
            }

            return list;
        }

        public static IEnumerable<string> EnumName<T>()
        {
            var list = new List<string>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                string name = Resources.ResourceManager.GetString(Enum.GetName(typeof(T), (int)value));

                if (string.IsNullOrEmpty(name))
                {
                    name = Enum.GetName(typeof(T), (int)value);
                }

                list.Add(name);
            }

            return list;
        }
        public static string GetTranslation(this Enum key)
        {
            try
            {
                var translation = Resources.ResourceManager.GetString(key.ToString());
                if (string.IsNullOrWhiteSpace(translation))
                {
                    translation = key.ToString();
                }

                return translation;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
