namespace OnlineSpreadsheet.Web.Application.Services
{
    using System;
    using System.Net;
    using OnlineSpreadsheet.Data.Common;

    public class DownloadService
    {
        public static void DownloadFile(string url, string downloadTo)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(new Uri(url), downloadTo);
                }
            }
            catch (Exception ex)
            {
                NLogger.Instance.Fatal(ex);
            }
        }
    }
}