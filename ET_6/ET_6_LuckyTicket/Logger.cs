﻿using log4net;
using log4net.Config;

namespace ET_6_LuckyTicket
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        static Logger()
        {
            XmlConfigurator.Configure();
        }
    }
}

