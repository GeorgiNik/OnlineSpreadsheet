namespace LibertyGlobalBP.Data.Common
{
    using NLog;

    public sealed class NLogger
    {
        private static Logger instance;

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = LogManager.GetCurrentClassLogger();
                }

                return instance;
            }
        }
    }
}
