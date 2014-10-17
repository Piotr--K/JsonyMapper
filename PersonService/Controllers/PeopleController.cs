using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonService.Models;

namespace PersonService.Controllers
{
    public class PeopleController : ApiController
    {
        private Person[] people = new Person[]
            {
                new Person {Age = "22", first_Name = "Piotr", last_Name = "K"},
                new Person {Age = "45", first_Name = "John", last_Name = "W"},
                new Person {Age = "12", first_Name = "Anna", last_Name = "S"}
            };

        public IEnumerable<Person> GetAllPeople()
        {
            return people;
        }
    }
}
