using System;

namespace DesignPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            Adapter.Run();
            ChainOfResponsibility.Run();
            Observer.Run();

            Console.ReadLine();
        }
    }
}

