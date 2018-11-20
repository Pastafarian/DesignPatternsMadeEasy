using System;

namespace DesignPatterns
{
    public static class SingletonExample
    {
        public class Singleton
        {
            private static readonly Singleton instance = new Singleton();

            static Singleton()
            {
            }

            public static Singleton Instance
            {
                get
                {
                    return instance;
                }
            }
        }

        public static void Run()
        {
            Console.WriteLine("Creating singleton instance");

            var singleton = Singleton.Instance;
        }
    }
}

