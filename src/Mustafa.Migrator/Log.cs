using System;
using Castle.Core.Logging;
using Abp.Dependency;
using Abp.Timing;
using log4net;

namespace Mustafa.Migrator
{
    public class Log : ITransientDependency
    {
        public ILogger Logger { get; set; }
        //private static ILog _log;

        public Log()
        {
            Logger = NullLogger.Instance;
            //_log = LogManager.GetLogger(typeof(Log));
        }

        public void Write(string text)
        {
            Console.WriteLine(Clock.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + text);
            Logger.Info(text);
            //_log.Error(text);
        }
    }
}
