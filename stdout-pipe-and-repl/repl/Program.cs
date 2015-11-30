using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("prompt>");
        Console.Out.Flush();
        var input = Console.ReadLine();
        Console.WriteLine("echo " + input);
        Console.ReadLine();
    }
}
