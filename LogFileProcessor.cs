using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogAnalyzer
{
    public class LogFileProcessor
    {
        public List<string> GetUniqueErrors(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return lines.Distinct().ToList();
        }

        public List<string> GetDuplicatedErrors(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return lines.GroupBy(line => line).Where(group => group.Count() > 1).Select(group => group.Key).ToList();
        }

        //TODO: Add more methods for processing log files here
    }
}
