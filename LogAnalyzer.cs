using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace LogAnalyzer
{
    public class LogAnalyzer
    {
        private readonly LogFileProcessor _processor;

        public LogAnalyzer()
        {
            _processor = new LogFileProcessor();
        }

        public void SearchLogs(string[] directories, string searchPattern)
        {
            foreach (var directory in directories)
            {
                var files = Utils.GetFiles(directory, searchPattern);
                foreach (var file in files)
                {
                    Console.WriteLine($"Found log file: {file}");
                }
            }
        }

        public void CountUniqueErrors(string[] directories, string searchPattern)
        {
            foreach (var directory in directories)
            {
                var files = Utils.GetFiles(directory, searchPattern);
                foreach (var file in files)
                {
                    var uniqueErrors = _processor.GetUniqueErrors(file);
                    Console.WriteLine($"File: {file} - Unique Errors: {uniqueErrors.Count}");
                }
            }
        }

        public void CountDuplicatedErrors(string[] directories, string searchPattern)
        {
            foreach (var directory in directories)
            {
                var files = Utils.GetFiles(directory, searchPattern);
                foreach (var file in files)
                {
                    var duplicateErrors = _processor.GetDuplicatedErrors(file);
                    Console.WriteLine($"File: {file} - Duplicated Errors: {duplicateErrors.Count}");
                }
            }
        }

        public void ArchiveLogs(string[] directories, DateTime startDate, DateTime endDate)
        {
            foreach (var directory in directories)
            {
                var files = Utils.GetFiles(directory, "*.log");
                var archiveName = $"{directory}/Archive_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.zip";
                using (var archive = ZipFile.Open(archiveName, ZipArchiveMode.Create))
                {
                    foreach (var file in files)
                    {
                        var fileDate = File.GetLastWriteTime(file);
                        if (fileDate >= startDate && fileDate <= endDate)
                        {
                            archive.CreateEntryFromFile(file, Path.GetFileName(file));
                            File.Delete(file);
                        }
                    }
                }
                Console.WriteLine($"Archived logs to {archiveName}");
            }
        }

        //TODO: Other methods for upload, delete, etc. can be implemented similarly
    }
}
