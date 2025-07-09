using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverLayoutData
{
    public class clsDataAccessSetting
    {
        public static string ConnectionString = @"server =.; database = DVLD; User ID= sa ; Password = sa123456;";


        public static void SetEventLog(string MessageText, EventLogEntryType type)
        {
            // Specify the source name for the event log
            string sourceName = "PDVLD";


            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
                Console.WriteLine("Event source created.");
            }


            // Log an information event
            EventLog.WriteEntry(sourceName, MessageText, type);

        }
    }
}
