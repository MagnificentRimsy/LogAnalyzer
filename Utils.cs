using System;
using System.Collections.Generic;
using System.IO;

namespace LogAnalyzer
{
    public static class Utils
    {
        public static IEnumerable<string> GetFiles(string path, string searchPattern)
        {
            var files = new List<string>();
            try
            {
                files.AddRange(Directory.GetFiles(path, searchPattern));
                foreach (var directory in Directory.GetDirectories(path))
                {
                    files.AddRange(GetFiles(directory, searchPattern));
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (DirectoryNotFoundException) { }

            return files;
        }
    }
}
