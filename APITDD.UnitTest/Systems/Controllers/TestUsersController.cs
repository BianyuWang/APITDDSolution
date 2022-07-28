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

            mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
            //Assert
          //  result.StatusCode.Should().Be(200);
        }

        //[Fact]
        //public async Task Get_OnSuccess_ReturnListOfUsers()
        //{
        //    //Arrange
        //    var mockUserService = new Mock<IUserService>();
        //    mockUserService
        //        .Setup(service => service.GetAllUsers())
        //   .ReturnsAsync(new List<User>());
        //    var sut = new UsersController(mockUserService.Object);

        //    //Act
        //    var result = await sut.Get();

        //    mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
        //    //Assert
        //    //  result.StatusCode.Should().Be(200);
        //}
    }
}