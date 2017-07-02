namespace OnlineSpreadsheet.Utilities.Common
{
    public class Reflection
    {
        public static object GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
    }
}
