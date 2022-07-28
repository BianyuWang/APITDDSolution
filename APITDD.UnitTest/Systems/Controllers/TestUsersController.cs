using APITDDSolution.API.Controllers;
using APITDDSolution.API.Models;
using APITDDSolution.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace APITDD.UnitTest.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            var mockUserService = new Mock<IUserService>();
            //Arrange
            var sut = new UsersController(mockUserService.Object);

            //Act
         var result =(OkObjectResult) await sut.Get();

            //Assert
           result.StatusCode.Should().Be(200);
        }


        [Fact]
        public async Task Get_OnSuccess_InvokesUserService()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service =>service.GetAllUsers())
            .ReturnsAsync(new List<User>());
                  var sut = new UsersController(mockUserService.Object);

            //Act
            var result = await sut.Get();
            //Assert
            mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
           
         
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfUsers()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
           .ReturnsAsync(new List<User>()
           { new User {
           Id= 1,
           FirstName="Lea",
           LastName ="Li",
           Address = new Address()
           { 
               CiviLNum = 1234,
               City="North Pole",
           PostalCode="h0h0h0",
           }
           }
           
           }
           );


            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = await sut.Get();


            //Assert
            result.Should().BeOfType<OkObjectResult>();

            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }


        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
           .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUserService.Object);

            //Act
            var result = await sut.Get();
            result.Should().BeOfType<NotFoundResult>();

            var objectResult = (NotFoundResult)result;

            objectResult.StatusCode.Should().Be(404);
        }

    }
}