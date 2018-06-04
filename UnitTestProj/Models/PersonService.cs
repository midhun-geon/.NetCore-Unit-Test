using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestProj.Models
{
    public class PersonService : IPersonService
    {
        public List<Person> Persons = new List<Person>();
        public static List<Person> Personrec = new List<Person>();

        public PersonService()
        {
            var i = 0;
            if (Persons!=null)
            {
                Persons = Persons.Take(50).ToList();
                Persons.ForEach(person =>
                {
                    i++;
                    person.Id = i;
                });
            }
            ListInitializer();
        }

        public IEnumerable<Person> GetAll()
        {
            return Persons;
        }
        public IEnumerable<Person> GetAllRec()
        {
            //return Persons;
            ListInitializer();
            return Personrec;
        }

        public Person Get(int id)
        {
            return Personrec.First(_ => _.Id == id);
        }

        public Person Add(Person person)
        {
            if (Persons.Count < 1)
            {
                person.Id = 1;
            }
            else
            {
                var newid = Persons.OrderBy(_ => _.Id).Last().Id + 1;
                person.Id = newid;
            }
            

            Persons.Add(person);

            return person;
        }

        public void Update(int id, Person person)
        {
            var existing = Personrec.First(_ => _.Id == id);
            existing.FirstName = person.FirstName;
            existing.LastName = person.LastName;
            existing.Address = person.Address;
            existing.Age = person.Age;
            existing.City = person.City;
            existing.Email = person.Email;
            existing.Phone = person.Phone;
            existing.Title = person.Title;
        }

        public void Delete(int id)
        {
            var existing = Personrec.First(_ => _.Id == id);
            Personrec.Remove(existing);
        }
        public void ListInitializer()
        {
            Personrec.Add(new Person { Id = 1, FirstName = "John", LastName = "brown", Title = "sdsds", Age = 12, Address = "orlando", City = "sdsd", Phone = "5665959", Email = "sdvkfvkfvfv" });
            Personrec.Add(new Person { Id = 2, FirstName = "Mac", LastName = "Zyn", Title = "sdsds", Age = 42, Address = "DR", City = "rtrt", Phone = "45454", Email = "ouiouiou" });

            Personrec.Add(new Person { Id = 3, FirstName = "Alf", LastName = "Con", Title = "sdsds", Age = 35, Address = "NY", City = "tyty", Phone = "5353", Email = "llopkjukj" });
            Personrec.Add(new Person { Id = 4, FirstName = "Dan", LastName = "Christian", Title = "sdsds", Age = 37, Address = "Ca", City = "nhju", Phone = "9524245", Email = "weqwqwqw" });

            Personrec.Add(new Person { Id = 5, FirstName = "Zean", LastName = "William", Title = "sdsds", Age = 30, Address = "OX", City = "ghyt", Phone = "36558", Email = "asZxsasa" });
            Personrec.Add(new Person { Id = 6, FirstName = "Shaun", LastName = "Marsh", Title = "sdsds", Age = 28, Address = "CAM", City = "fgrtt", Phone = "87153", Email = "vbvnbnghg" });

            Personrec.Add(new Person { Id = 7, FirstName = "Steve", LastName = "waugh", Title = "sdsds", Age = 42, Address = "Harward", City = "dfere", Phone = "10234", Email = "jkjkjly" });
            Personrec.Add(new Person { Id = 8, FirstName = "Daniel", LastName = "Craig", Title = "sdsds", Age = 26, Address = "Ben", City = "sdcr", Phone = "538278", Email = "mjkjkuyu" });
        }
    }

    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person person);
        void Update(int id, Person person);
        void Delete(int id);
        IEnumerable<Person> GetAllRec();
    }
}
