namespace OnlineSpreadsheet.Web.ViewModels.Infrastructure
{
    using System;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ExportAttribute : Attribute
    {
    }
}