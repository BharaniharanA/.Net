using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "File.txt";

        string[] lines = {"Hello World!....","Welcome to C#....","File Handling.....","GoodBye....."};

        // Writing to file
        File.WriteAllLines(filePath, lines);
        Console.WriteLine("Data written to file.\n");

        // Reading from file
        string[] readLines = File.ReadAllLines(filePath);

        Console.WriteLine("Reading from file:\n");
        foreach (string line in readLines)
        {
            Console.WriteLine(line);
        }
    }
}