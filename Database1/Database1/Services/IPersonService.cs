using System;
using System.Collections.Generic;
using System.Text;
using Database1.Models;

namespace Database1.Services
{
    public interface IPersonService
    {
        //CRUD
        Person Create(Person newPerson);
        List<Person> Read();
    }
}
