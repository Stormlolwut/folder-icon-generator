using System;
using System.Collections.Generic;

namespace image_to_ico.Managers
{
    public interface IDirectoryManager
    {
        List<string> GetFilesFromDirectory(string path, bool verbose  = true, string[] extensions = null);
        string GetFile(string path);
    }
}