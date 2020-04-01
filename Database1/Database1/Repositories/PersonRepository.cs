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

        void IPersonRepository.Delete(long id)
        {
            throw new NotImplementedException();
        }

        List<Person> IPersonRepository.Read()
        {
            var persons = _context.Person.ToList();
            return persons;
        }

        Person IPersonRepository.Update(Person updatePerson)
        {
            throw new NotImplementedException();
        }
    }
}
