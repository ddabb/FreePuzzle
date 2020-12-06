using log4net;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4netServer.config", Watch = true)]
namespace FreePuzzle.Service
{
    public class Aop
    {
        public static ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
