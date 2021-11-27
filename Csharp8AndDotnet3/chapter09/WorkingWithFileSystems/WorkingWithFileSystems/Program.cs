using System;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputFileSystemInfo();
        }

        static void OutputFileSystemInfo()
        {
            WriteLine("{0,-33} {1}","Path.PathSeparator",PathSeparator);
            WriteLine("{0,-33} {1}","Path.DirectorySeparatorChar",DirectorySeparatorChar);
            WriteLine("{0,-33} {1}","Directory.GetCurrentDirectory()",GetCurrentDirectory());
            WriteLine("{0,-33} {1}","Environment.CurrentDirectory",CurrentDirectory);
        }
    }
}