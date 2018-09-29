using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public static class ChainOfResponsibility
    {

        public enum Language
        {
            English,
            French
        }

        public abstract class Greeter
        {
            private Greeter next;

            public Greeter SetNext(Greeter nextGreeter)
            {
                next = nextGreeter;
                return this;
            }

            public abstract void Handle(Language language);

            protected void RunNext(Language language)
            {
                next?.Handle(language);
            }
        }

        public class EnglishGreeter : Greeter
        {
            public override void Handle(Language language)
            {
                if (language == Language.English) Console.WriteLine("Hello world");

                RunNext(language);
            }
        }

        public class FrenchGreeter : Greeter
        {
            public override void Handle(Language language)
            {
                if (language == Language.English) Console.WriteLine("Bonjour monde");

                RunNext(language);
            }
        }

        public static void Run()
        {
            var greeter = new EnglishGreeter().SetNext(new FrenchGreeter());

            greeter.Handle(Language.English);
            greeter.Handle(Language.French);
        }
    }
}
