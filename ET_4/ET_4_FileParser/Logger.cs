using log4net;
using log4net.Config;

namespace ET_4_FileParser
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
