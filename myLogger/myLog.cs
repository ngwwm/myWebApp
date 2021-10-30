using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myLogger
{
    public static class myLog
    {
        public static log4net.ILog mlog;
        static myLog()
        {
            log4net.Config.XmlConfigurator.Configure();

            mlog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
