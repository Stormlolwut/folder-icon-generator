using System;
using System.IO;
using System.Linq;
using image_to_ico.Managers;

namespace image_to_ico
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Log] 1/2 - Searching for files...");
            var results = new DirectoryManager().GetFilesFromDirectory("root");
            
            Console.WriteLine("[Log] 2/2 - Files found: ");
            foreach (var fi in results.Select(result => new FileInfo(result)))
            {
                Console.WriteLine($" - {fi.Name}");
            }
            
            Console.ReadLine();

        }
    }
}