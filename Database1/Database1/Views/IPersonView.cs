using System;
using System.Collections.Generic;
using System.Text;

namespace Database1.Views
{
    public interface IPersonView
    {
        void CreatePerson();
        void ReadAllData();
        void ReadById();
        void UpdatePerson();
        void DeletePerson();
    }
}
