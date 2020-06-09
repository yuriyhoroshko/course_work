using log4net;
using log4net.Config;

namespace SystemResourceReporterService
{
    public class LoggerInstance
    {
        private static ILog log = LogManager.GetLogger("LOGGER");


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
