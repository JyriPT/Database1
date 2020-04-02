using Database1.Models;
using Database1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database1.Services
{
    class PersonService : IPersonService
    {
        //Inject PersonRepository
        private readonly IPersonRepository _personRepository;

        public PersonService()
        {
            _personRepository = new PersonRepository();
        }
        public Person Create(Person newPerson)
        {
            var createdPerson = _personRepository.Create(newPerson);
            return createdPerson;
        }

        public void Delete(int id)
        {
            var getPerson = Read(id);

            if (getPerson == null)
            {
                Console.WriteLine("Poisto ei onnistunut, henkilöä ei löytynyt");
            } else
            {
                _personRepository.Delete(getPerson);
                Console.WriteLine("Henkilö poistettu");
            }


        }

        public List<Person> Read()
        {
            var persons = _personRepository.Read();
            return persons;
        }

        public Person Read(int id)
        {
            var person = _personRepository.Read(id);
            return person;
        }

        /// <summary>
        /// Find Person by id
        /// if found, update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatePerson"></param>
        /// <returns></returns>
        public Person Update(int id, Person updatePerson)
        {
            var getPerson = Read(id);

            if (getPerson == null)
            {
                Console.WriteLine("Päivitys ei onnistunut, henkilöä ei löytynyt");
                return null;
            }

            var updatedPerson = _personRepository.Update(updatePerson);
            return updatedPerson;
        }
    }
}
