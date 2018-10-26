using System;
using System.Diagnostics;

namespace DesignPatterns
{
    public static class Adapter
    {
        public interface IPerson
        {
            string Name { get; set; }
        }

        public interface IFrenchPerson
        {
            string Nom { get; set; }
        }

        public class Person : IPerson
        {
            public Person(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
        }

        public class FrenchPerson : IFrenchPerson
        {
            public FrenchPerson(string nom)
            {
                Nom = nom;
            }

            public string Nom { get; set; }
        }

        public class PersonService
        {
            public void PrintName(IPerson person)
            {
                Console.WriteLine(person.Name);
            }
        }


        public class FrenchPersonAdapter : IPerson
        {
            private readonly IFrenchPerson frenchPerson;

            public FrenchPersonAdapter(IFrenchPerson frenchPerson)
            {
                this.frenchPerson = frenchPerson;
            }

            public string Name
            {
                get { return frenchPerson.Nom; }
                set { frenchPerson.Nom = value; }
            }
        }

        public static void Run()
        {
            var service = new PersonService();
            var person = new Person("Jack");
            var frenchPerson = new FrenchPerson("Jacques");

            service.PrintName(person);
            service.PrintName(new FrenchPersonAdapter(frenchPerson));

        }
    }
}
