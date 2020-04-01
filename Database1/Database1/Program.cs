using System;
using System.Linq;
using Database1.Data;
using Database1.Views;

namespace Database1
{
    class Program
    {
        static private readonly PersondbContext context = new PersondbContext();
        static private readonly IPersonView _personView = new PersonView();

        static void Main(string[] args)
        {
            string choice = null;

            string msg = "";
            do
            {
                choice = UserInterface();

                switch (choice.ToUpper())
                {
                    case "C":

                        _personView.CreatePerson();
                        msg = "\n----------------------------> \nPaina Enter jatkaaksesi!";
                        break;
                    case "R":
                        //personView.Read(5002);
                        _personView.ReadAllData();
                        msg = "\n----------------------------> \nPaina Enter jatkaaksesi!";
                        break;
                    case "U":
                        //personView.UpdatePerson();
                        msg = "\n---------------------------->! \nPaina Enter jatkaaksesi!";
                        break;
                    case "D":
                        //personView.DeletePerson(5003);
                        msg = "\n---------------------------->! \nPaina Enter jatkaaksesi!";
                        break;
                    case "R1":
                        //personView.ReadByCity(); ;
                        msg = "\n----------------------------> \nPaina Enter jatkaaksesi!";
                        break;
                    case "X":
                        msg = "\nOhjelman suoritus päättyy!";
                        break;
                    default:
                        msg = "Nyt tuli huti yritä uudestaan - Paina Enter ja aloita alusta!";
                        break;
                }

                Console.WriteLine(msg);
                Console.ReadLine();
                Console.Clear();
            }
            while (choice.ToUpper() != "X");

        }

        static string UserInterface()
        {
            Console.WriteLine("Tietokannan käsittely esimerkki!");
            Console.WriteLine("[C] Lisää tietokantaan uusi tietue");
            Console.WriteLine("[R] Lue tietokannasta tietoja");
            Console.WriteLine("[U] Päivitä henkilön tiedot");
            Console.WriteLine("[D] Poista henkilö tietokannasta");
            Console.WriteLine("[R1] Hae tiedot kaupungista");
            Console.WriteLine("[X] Lopeta ohjelmansuoritus");
            Console.WriteLine();
            Console.Write("Valitse mitä tehdään: ");

            return Console.ReadLine();
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
