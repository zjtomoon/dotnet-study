using System;
using System.IO;
using static System.Console;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;

namespace WorkingWithDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkWithDirectories();
            WorkWithFiles();
        }

        static void WorkWithDirectories()
        {
            var newFolder = Combine(
                GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "NewFolder");
            WriteLine($"Working with: {newFolder}");
            
            WriteLine($"Does it exists? {Exists(newFolder)}");
            
            WriteLine("Creating it ...");
            CreateDirectory(newFolder);
            WriteLine($"Does it exist? {Exists(newFolder)}");
            
            WriteLine("Confirm the directory exists,and then press ENTER: ");
            ReadLine();
            
            WriteLine("Deleting it ...");
            Delete(newFolder,recursive: true);
            WriteLine($"Does it exists? {Exists(newFolder)}");
        }

        static void WorkWithFiles()
        {
            var dir = Combine(
                GetFolderPath(SpecialFolder.Personal),"Code","Chapter09","OutputFiles");
            CreateDirectory(dir);
            
            //定义文件目录
            string textFile = Combine(dir, "Dummy.txt");
            string backupFile = Combine(dir, "Dummy.bak");
            
            WriteLine($"Working with : {textFile}");
            
            WriteLine($"Does it exists? {File.Exists(textFile)}");

            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello,C#!");
            textWriter.Close();
            
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            File.Copy(sourceFileName: textFile,destFileName: backupFile, overwrite: true);
            WriteLine($"Does {backupFile} exist ? {File.Exists(backupFile)}");
            WriteLine("Confirm the files exist, and then press ENTER: ");
            ReadLine();
            
            File.Delete(textFile);
            
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            
            WriteLine($"Reading contents of {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            WriteLine(textReader.ReadToEnd());
            textReader.Close();
        }
    }
}