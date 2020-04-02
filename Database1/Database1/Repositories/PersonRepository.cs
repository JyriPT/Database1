using Database1.Models;
using Database1.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Database1.Repositories
{
    class PersonRepository : IPersonRepository
    {
        //Inject DatabaseContext
        private readonly PersondbContext _context;

        //Default constructor
        public PersonRepository()
        {
            _context = new PersondbContext();
        }

        /// <summary>
        /// Find person by Id
        /// SELECT * FROM PERSON WHERE Id = @id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person Read(int id)
        {
            var person = _context.Person.FirstOrDefault(p=>p.Id == id);
            return person;
        }

        /// <summary>
        /// INSERT INTO PERSON (Name, Age) VALUES (newPerson.Name, newPerson.Age)
        /// </summary>
        /// <param name="newPerson"></param>
        /// <returns></returns>
        Person IPersonRepository.Create(Person newPerson)
        {
            try
            {
                _context.Person.Add(newPerson);
                _context.SaveChanges();
                return newPerson;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        void IPersonRepository.Delete(Person deletePerson)
        {
            _context.Person.Remove(deletePerson);
            _context.SaveChanges();
        }

        /// <summary>
        /// All data from Person
        /// SELECT * FROM PERSON
        /// </summary>
        /// <returns></returns>
        List<Person> IPersonRepository.Read()
        {
            var persons = _context.Person.ToList();
            return persons;
        }

        Person IPersonRepository.Update(Person updatePerson)
        {
            _context.Person.Update(updatePerson);
            _context.SaveChanges();
            return updatePerson;
        }
    }
}
