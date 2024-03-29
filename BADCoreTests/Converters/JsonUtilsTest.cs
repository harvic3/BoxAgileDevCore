﻿using BoxAgileDevCore.Controller.Utils;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BoxAgileDevUnitTests.TestClasses.TestClasses;

namespace BoxAgileDevUnitTests.Converters
{
  [TestClass]
  public class JsonUtilsTest
  {
    [TestInitialize]
    public void Init()
    {
    }

    [TestMethod]
    public void DynamicMappingToPersonWithDataMemberObjectTest()
    {
      // Arrange
      dynamic person = "{\r\n  \"name\": \"Jhon\",\r\n  \"lastName\": \"Doe\"\r\n}";

      // Act
      PersonDto personMapped = JsonUtils.DeserializeObject<PersonDto>( person );

      // Assert
      personMapped.Name.Should().Be( "Jhon" );
      personMapped.LastName.Should().Be( "Doe" );
    }

    [TestMethod]
    public void ObjectMappingToPersonWithDataMemberObjectTest()
    {
      // Arrange
      PersonDto person = new PersonDto
      {
        Name = "Jhon",
        LastName = "Doe",
        Document = DocumentType.Passport
      };

      // Act
      string personStr = JsonUtils.SerializeObject( person );

      // Assert
      personStr.Should().Be( "{\r\n  \"name\": \"Jhon\",\r\n  \"lastName\": \"Doe\",\r\n  \"document\": 1\r\n}" );
    }

    [TestMethod]
    public void ObjectMappingToPersonObjectTest()
    {
      // Arrange
      Person person = new Person
      {
        Name = "Jhon",
        LastName = "Doe",
        Document = DocumentType.Passport
      };

      // Act
      string personStr = JsonUtils.SerializeObject( person );

      // Assert
      personStr.Should().Be( "{\r\n  \"Name\": \"Jhon\",\r\n  \"LastName\": \"Doe\",\r\n  \"Document\": 1\r\n}" );
    }
  }

}
