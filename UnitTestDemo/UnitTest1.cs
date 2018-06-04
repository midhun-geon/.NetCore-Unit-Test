using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestProj.Controllers;
using UnitTestProj.Models;
using Xunit;

namespace UnitTestDemo
{
    public class UnitTest1
    {
        [Fact]
        public async Task Values_Get_All()
        {
            var controller = new PersonsController(new PersonService());

            var result = await controller.GetRec();

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Person>>().Subject;

            persons.Count().Should().Be(8);
        }
        [Fact]
        public async Task PostTest()
        {
            var controller = new PersonsController(new PersonService());
            var newPerson = new Person{
                FirstName="Wayne",
                LastName="Rooney",
                Title="Footballer",
                Age=32,
                Address="Manchester",
                City="United",
                Phone="9875486",
                Email="rooney@gmail.com"
            };
            var result = await controller.Post(newPerson);
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
            person.Id.Should().Be(1);
        }
        [Fact]
        public async Task UpdateTest()
        {
            var controller = new PersonsController(new PersonService());
            PersonService ser = new PersonService();
            var newPerson = new Person
            {
                FirstName = "Wayne",
                LastName = "Rooney",
                Title = "Footballer",
                Age = 32,
                Address = "Manchester",
                City = "United",
                Phone = "9875486",
                Email = "rooney@gmail.com"
            };
            var result = await controller.Put(2, newPerson);
            var okResult = result.Should().BeOfType<NoContentResult>().Subject;
            var getResult = ser.Get(2);
            getResult.Id.Should().Be(2);
            getResult.FirstName.Should().Be("Wayne");
            getResult.LastName.Should().Be("Rooney");

        }
        [Fact]
        public  async Task DeleteTest()
        {
            
            var service = new PersonService();
            var controller = new PersonsController(service);
            var result = await controller.Delete(4);
            var OKresult = result.Should().BeOfType<NoContentResult>().Subject;
            AssertionExtensions.ShouldThrow<InvalidOperationException>(
               () => service.Get(4));

        }
    }
}
