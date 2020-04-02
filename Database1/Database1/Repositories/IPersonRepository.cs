using System;
using System.Collections.Generic;
using System.Text;
using Database1.Models;

namespace Database1.Repositories
{
    public interface IPersonRepository
    {
        // CRUD
        Person Create(Person newPerson);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person updatePerson);
        void Delete(Person deletePerson);
    }
}
