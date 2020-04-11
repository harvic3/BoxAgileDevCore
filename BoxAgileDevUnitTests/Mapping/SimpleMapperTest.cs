using BoxAgileDev.Mapping;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static BoxAgileDevUnitTests.TestClasses.TestClasses;

namespace BoxAgileDevUnitTests.Mapping
{
    [TestClass]
    public class SimpleMapperTest
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void MappingPersonObjectTest()
        {
            // Arrange
            Person person = new Person
            {
                Name = "Jhon",
                LastName = "Doe",
                Document = DocumentType.Passport
            };

            // Act
            var personMapped = SimpleMapper.MapObject<Person>(person);

            // Assert
            personMapped.Name.Should().Be(person.Name);
            personMapped.LastName.Should().Be(person.LastName);
            personMapped.Document.Should().Be(person.Document);
        }
        
        [TestMethod]
        public void MappingPersonWithNacionalityObjectTest()
        {
            // Arrange
            PersonWithNacionality person = new PersonWithNacionality
            {
                Name = "Jhon",
                LastName = "Doe",
                Document = DocumentType.Passport,
                Nacionality = new Nacionality
                {
                    City = "Medellín",
                    Country = "Colombia",
                    State = "Antioquia"
                }
            };

            // Act
            PersonWithNacionality personMapped = SimpleMapper.MapObject<PersonWithNacionality>(person);

            // Assert
            personMapped.Name.Should().Be(person.Name);
            personMapped.Nacionality.City.Should().Be(person.Nacionality.City);
            personMapped.Document.Should().Be(person.Document);
        }

        [TestMethod]
        public void MapPersonCollectionTest()
        {
            // Arrange
            var persons = new List<PersonDto>(){
                new PersonDto
                {
                    Name = "Jhon",
                    LastName = "Doe",
                    Document = DocumentType.Passport
                },
                new PersonDto
                {
                    Name = "Nikola",
                    LastName = "Tesla",
                    Document = DocumentType.Passport
                },
                new PersonDto
                {
                    Name = "Michael",
                    LastName = "Faraday",
                    Document = DocumentType.Card
                }
            };

            // Act
            var personsMapped = SimpleMapper.MapCollection<PersonDto, Person>(persons);

            // Assert
            personsMapped.Count().Should().Be(persons.Count());
            personsMapped[1].LastName.Should().Be("Tesla");
        }

    }

}
