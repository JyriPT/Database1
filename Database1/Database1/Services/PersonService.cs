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

        public List<Person> Read()
        {
            var persons = _personRepository.Read();
            return persons;
        }
    }
}
