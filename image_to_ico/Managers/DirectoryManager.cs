using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace image_to_ico.Managers
{
    public class DirectoryManager : IDirectoryManager
    {
        private string[] _extensions = {".jpg", ".jpeg", ".png", ".gif"};
        public List<string> GetFilesFromDirectory(string path, bool verbose = true, string[] extensions = null)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            _extensions = extensions ?? _extensions;
           
            FileInfo[] files = null;
            List<string> filteredFiles = new List<string>();

            if(verbose) Console.WriteLine($"[Log] Searching {root.Name}");
            
            try { files = root.GetFiles("*.*"); }
            catch (Exception e) { Console.WriteLine($"[Error]: {e.Message} at {e.Source}"); }
            
            filteredFiles = files?.Where(e => _extensions.Contains(e.Extension)).Select(e => e.FullName).ToList();
            
            foreach (var directory in root.GetDirectories())
            {
                filteredFiles?.AddRange(GetFilesFromDirectory(directory.FullName, verbose, extensions));
            }

            return filteredFiles;
        }

        public string GetFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}