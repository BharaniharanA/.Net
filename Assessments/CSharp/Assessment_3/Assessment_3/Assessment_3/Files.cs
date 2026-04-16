using System;
using System.IO;

namespace Assessment_3
{
    public class Files
    {
        public void FilesOperation(string path, string content)
        {
            Console.WriteLine();
            if (File.Exists(path))
            {
                Console.WriteLine("[File exist....]");
            }
            else
            {
                Console.WriteLine("[File not exist....]");
                Console.WriteLine("[File created....]");
            }
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(content);
            sw.Close();
            fs.Close();
            Console.WriteLine("[Text added to file successfully....]");
        }
        public void FileRead(string path)
        {
            Console.WriteLine();
            Console.WriteLine("[Data in the file...]");
            Console.WriteLine();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            Console.WriteLine(sw.ReadToEnd());
            sw.Close();
            fs.Close();
        }
    }
    public class FileMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("==== Welcome to File Operation ====");
            Console.WriteLine();

            Files files = new Files();
            Console.Write("Enter the file path: ");
            string filepath = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Enter the text to add in the file:");
            string filecontent = Console.ReadLine();
            files.FilesOperation(filepath, filecontent);
            files.FileRead(filepath);

            Console.WriteLine("====================================");
        }

    }
}
