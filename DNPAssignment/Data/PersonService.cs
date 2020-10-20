using DNPAssignment.FileData;
using DNPAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment.Data
{
    public class PersonService : IPersonService
    {
        private FileContext fileContext;

        public PersonService()
        {
            fileContext = new FileContext();
        }

        public void AddPerson(Adult person)
        {
            int max;
            try
            {
                max = fileContext.Adults.Max(person => person.Id);
            }
            catch
            {
                max = 1;
            }
            person.Id = (++max);
            if(person is Adult)
            {
                fileContext.Adults.Add(person);
                fileContext.SaveChanges();
            }

        }

        public IList<Adult> GetPeople()
        {
            List<Adult> temp = new List<Adult>(fileContext.Adults);
            return temp;
        }

        public void RemovePerson(int personID)
        {
            Adult toRemove = fileContext.Adults.First(t => t.Id == personID);
            fileContext.Adults.Remove(toRemove);
            fileContext.SaveChanges();
        }

        public void UpdatePerson(Adult person)
        {
            Adult toUpdate = fileContext.Adults.First(t => t.Id == person.Id);
            toUpdate.JobTitle = person.JobTitle;
            toUpdate.Id = person.Id;
            toUpdate.FirstName = person.FirstName;
            toUpdate.LastName = person.LastName;
            toUpdate.HairColor = person.HairColor;
            toUpdate.EyeColor = person.EyeColor;
            toUpdate.Age = person.Age;
            toUpdate.Weight = person.Weight;
            toUpdate.Height = person.Height;
            toUpdate.Sex = person.Sex;
            fileContext.SaveChanges();
        }
    }
}
