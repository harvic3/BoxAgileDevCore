using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxAgileDevCore.Result.Generic;
using BoxAgileDevCore.Result;
using FluentAssertions;
using System.Linq;

namespace BADCoreTests.Result
{
  [TestClass]
  public class ResultTest
  {
    [TestInitialize]
    public void Init()
    {

    }

    [TestMethod]
    public void ResultWithError() {
      // Arrange
      var result = new BaseResult();
      const string errorMessage = "An error to test";

      // Act
      result.SetError( errorMessage, System.Net.HttpStatusCode.BadRequest );

      // Assert
      result.HasErrors().Should().BeTrue();
      result.HasMessages().Should().BeFalse();
      result.Success.Should().BeFalse();
      result.Messages.Count.Should().Be( 1 );
      result.Messages.First().Should().Be( errorMessage );
      result.StatusCode.Should().Be( System.Net.HttpStatusCode.BadRequest );
    }

    [TestMethod]
    public void ResultWithErrors()
    {
      // Arrange
      var result = new BaseResult();
      const string errorMessageOne = "An error to test 1";
      const string errorMessageTwo = "An error to test 2";

      // Act
      result.AddError( errorMessageOne );
      result.AddError( errorMessageTwo );

      // Assert
      result.HasErrors().Should().BeTrue();
      result.HasMessages().Should().BeFalse();
      result.Success.Should().BeFalse();
      result.Messages.Count.Should().Be( 2 );
      result.Messages.First().Should().Be( errorMessageOne );
      result.StatusCode.Should().Be( System.Net.HttpStatusCode.InternalServerError );
    }

    [TestMethod]
    public void ResultWithSuccess()
    {
      // Arrange
      var result = new BaseResult();
      const string message = "A success message";

      // Act
      result.SetMessage( message, System.Net.HttpStatusCode.OK );

      // Assert
      result.HasErrors().Should().BeFalse();
      result.HasMessages().Should().BeTrue();
      result.Success.Should().BeTrue();
      result.Messages.Count.Should().Be( 1 );
      result.Messages.First().Should().Be( message );
      result.StatusCode.Should().Be( System.Net.HttpStatusCode.OK );
    }

    [TestMethod]
    public void ResultGenericWithError() {
      // Arrange
      var result = new BaseResult<string>();
      const string errorMessage = "An error to test";

      // Act
      result.SetError( errorMessage, System.Net.HttpStatusCode.BadRequest );

      // Assert
      result.HasErrors().Should().BeTrue();
      result.HasMessages().Should().BeFalse();
      result.Success.Should().BeFalse();
      result.Messages.Count.Should().Be( 1 );
      result.Messages.First().Should().Be( errorMessage );
      result.StatusCode.Should().Be( System.Net.HttpStatusCode.BadRequest );
    }

    [TestMethod]
    public void ResultGenericWithErrors()
    {
      // Arrange
      var result = new BaseResult<string>();
      const string errorMessageOne = "An error to test 1";
      const string errorMessageTwo = "An error to test 2";

      // Act
      result.AddError( errorMessageOne );
      result.AddError( errorMessageTwo );

      // Assert
      result.HasErrors().Should().BeTrue();
      result.HasMessages().Should().BeFalse();
      result.Success.Should().BeFalse();
      result.Messages.Count.Should().Be( 2 );
      result.Messages.First().Should().Be( errorMessageOne );
      result.StatusCode.Should().Be( System.Net.HttpStatusCode.InternalServerError );
    }

    [TestMethod]
    public void ResultGenericWithSuccess()
    {
      // Arrange
      var result = new BaseResult<string>();
      const string message = "A success message";
      const string data = "data";

      // Act
      result.SetSuccess( data, message );

      // Assert
      result.HasErrors().Should().BeFalse();
      result.HasMessages().Should().BeTrue();
      result.Success.Should().BeTrue();
      result.Messages.Count.Should().Be( 1 );
      result.Messages.First().Should().Be( message );
      result.Result.Should().Be( data );
      result.StatusCode.Should().Be( System.Net.HttpStatusCode.OK );
    }
  }
}
