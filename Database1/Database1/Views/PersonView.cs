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
            newPerson.Name = "Testie Testington";

            var createdPerson = _personService.Create(newPerson);
            Console.WriteLine("Person created successfully");
            Console.WriteLine(newPerson.Name);
        }

        public void ReadAllData()
        {
            var persons = _personService.Read();
            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}
