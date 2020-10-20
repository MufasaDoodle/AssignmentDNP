using DNPAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment.Data
{
    interface IPersonService
    {
        IList<Adult> GetPeople();
        void AddPerson(Adult person);
        void RemovePerson(int personID);
        void UpdatePerson(Adult person);
    }
}
