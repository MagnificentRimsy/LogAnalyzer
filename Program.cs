using System;

namespace LogAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            // Sample Usage
            string[] directories = { @"C:\AmadeoLogs", @"C:\AWIErrors", @"C:\Loggings" };
            string searchPattern = "*.log";
            
            // Search Logs
            analyzer.SearchLogs(directories, searchPattern);

        }
    }
}
