using Database1.Models;
using Database1.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database1.Views
{
    class PersonView : IPersonView
    {
        //Inject Person Service layer
        private readonly IPersonService _personService = new PersonService();

        public void CreatePerson()
        {
            Person newPerson = new Person();
            string input = string.Empty;

            while (input == string.Empty)
            {
                Console.WriteLine("Anna henkilölle nimi:");
                input = Console.ReadLine();
            }

            newPerson.Name = input;



            var createdPerson = _personService.Create(newPerson);
            Console.WriteLine("Person created successfully");
            Console.WriteLine(newPerson.Name);
        }

        public void DeletePerson()
        {
            Console.Write("Kenen tiedot poistetaan? Syötä id:");
            var userInput = Console.ReadLine();

            int id = int.Parse(userInput);

            _personService.Delete(id);
        }

        public void ReadAllData()
        {
            var persons = _personService.Read();
            PrintPersonData(persons);
        }

        public void ReadById()
        {
            Console.WriteLine("Syötä etsittävä id");
            
            if (int.TryParse(Console.ReadLine(), out int id ) == true)
            {
                var person = _personService.Read(id);
                PrintPersonData(person);
            }
        }

        public void UpdatePerson()
        {
            Console.Write("Kenen tietoja muutetaan? Syötä id:");
            var userInput = Console.ReadLine();

            int id = int.Parse(userInput);

            var person = _personService.Read(id);

            Console.WriteLine("Anna henkilön uusi nimi:");
            userInput = Console.ReadLine();

            person.Name = userInput;

            var updatedPerson = _personService.Update(id, person);

            PrintPersonData(updatedPerson);
        }

        private void PrintPersonData(List<Person> persons)
        {
            Console.WriteLine("ID\tNimi");
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Id}\t{person.Name}");
                foreach (var phone in person.Phone)
                {
                    Console.WriteLine($"{phone.Type}: {phone.Number}");
                }
            }
        }

        private void PrintPersonData(Person person)
        {
            Console.WriteLine("ID\tNimi");
            Console.WriteLine($"{person.Id}\t{person.Name}");
            foreach (var phone in person.Phone)
            {
                Console.WriteLine($"{phone.Type}: {phone.Number}");
            }
        }
    }
}
