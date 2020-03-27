using System;
using Database1.Data;
using System.Linq;

namespace Database1
{
    class Program
    {
        static private readonly PersondbContext context = new PersondbContext();

        static void Main(string[] args)
        {
            Console.WriteLine("Tulosta kaikki henkilöt:");
            PrintAll();
        }

        static void PrintAll()
        {
            var persons = context.Person.ToList();

            foreach (var p in persons)
            {
                Console.WriteLine($"Nimi: {p.Name}, Ikä: {p.Age}");
            }
        }
    }
}
