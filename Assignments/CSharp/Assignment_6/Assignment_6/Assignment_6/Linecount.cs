using System;
using System.IO;

class Linecount
{
    static void Main()
    {
        string filePath = "File.txt";

        int lineCount = File.ReadAllLines(filePath).Length;

        Console.WriteLine("Number of lines in file: " + lineCount);
    }
}