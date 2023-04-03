using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cpShared.Helpers
{
    public class NamingHelper
    {
        public static List<string> ReplacementNames(IEnumerable<string> regNames, IEnumerable<string> existingNames, string suffixTemplate = " (v{0})")
        {
            HashSet<string> existing = new HashSet<string>(existingNames);
            return regNames.Aggregate(new List<string>(),
                (List<string> newNames, string name) =>
                {
                    var newName = name;
                    if (existing.Contains(newName))
                    {
                        foreach (var i in Enumerable.Range(1, 100)) // try up to 100 times to make a new unique name
                        {
                            var _suff = string.Format(suffixTemplate, i);
                            newName = $"{name}{_suff}";
                            if (!existing.Contains(newName)) break;
                        }
                    }
                    newNames.Add(newName);
                    existing.Add(newName);
                    return newNames;
                }
            );
        }

        public static string GetNameFromIds(List<string> names, int noToKeep)
        {
            string longList = names.Count > noToKeep ? "_etc" : "";
            List<string> idsForReportName = names.Take(noToKeep).ToList();
            string stringJoinSubstring = String.Join("_", idsForReportName.ToArray()) + longList;
            return stringJoinSubstring;
        }

        private static string numberPattern = " ({0})";


        public static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder", "pattern");

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }

        string GetAndCheckTempPathForUser(string fileName)
        {
            //basic option
            string dir = Path.GetTempPath();
            var testFn = Path.Combine(dir, fileName);
            if (IsDirectoryWritable(testFn)) return testFn;

            dir = KnownFolders.Downloads.Path;
            testFn = Path.Combine(dir, fileName);
            if (IsDirectoryWritable(testFn)) return testFn;
            return null;
        }

        public bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        dirPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                if (throwIfFails)
                    throw;
                else
                    return false;
            }
        }
    }
}
