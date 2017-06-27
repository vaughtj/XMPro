using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMProService
{
    public class LogEvent
    {
        public LogEvent()
        {
        }

        public static void LogMe(string LogText)
        {
            string eventSourceName = "XMPro Service"; string logName = "XMProLog"; 

            if (!System.Diagnostics.EventLog.SourceExists(eventSourceName))
            {

                System.Diagnostics.EventLog.CreateEventSource(eventSourceName, logName);
            }

            EventLog myLog = new EventLog();
            myLog.Source = eventSourceName;

            // Write an informational entry to the event log.    
            myLog.WriteEntry(LogText);
        }

    }
}
