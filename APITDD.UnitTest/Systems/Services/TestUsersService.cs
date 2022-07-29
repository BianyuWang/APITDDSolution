using APITDD.UnitTest.Fixtures;
using APITDD.UnitTest.Helpers;
using APITDDSolution.API.Config;
using APITDDSolution.API.Models;
using APITDDSolution.API.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITDD.UnitTest.Systems.Services
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvoikesHttpGetRequest()
        {
            //Arrage
            var expectedResponse = UserFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var endpoint = "https://example.com/users";
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersAPIOptions

            {
                Endpoint = endpoint

            });

            var sut = new UserService(httpClient,config);

            //Act
            await sut.GetAllUsers();

            //Assert
            //verify HTTP request is made!

            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1)
                , ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get)
                , ItExpr.IsAny<CancellationToken>()
                );

         
      

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsers()
        {
            var expectedResponse = UserFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>
                .SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://example.com/users";

            var config = Options.Create(new UsersAPIOptions

            {
                Endpoint = endpoint

            });
            var sut = new UserService(httpClient,config);
            var  result= await sut.GetAllUsers();

            result.Should().BeOfType<List<User>>();


        }


        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListOfUsers()
        {
            var expectedResponse = UserFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupReturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://example.com/users";

            var config = Options.Create(new UsersAPIOptions

            {
                Endpoint = endpoint

            });
            var sut = new UserService(httpClient, config);
            var result = await sut.GetAllUsers();

            result.Count.Should().Be(0);


        }


        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpextedSize()
        {
            var expectedResponse = UserFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>
             .SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var endpoint = "https://example.com/users";
            var config = Options.Create(new UsersAPIOptions

            {
                Endpoint = endpoint

            });
            var sut = new UserService(httpClient, config);
            var result = await sut.GetAllUsers();

            result.Count.Should().Be(expectedResponse.Count());


        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {
            var expectedResponse = UserFixture.GetTestUsers();

            var endpoint = "https//jsonplaceholder.typicode.com/users";
            var handlerMock = MockHttpMessageHandler<User>
             .SetupBasicGetResourceList(expectedResponse,endpoint);
            var httpClient = new HttpClient(handlerMock.Object);


            var config = Options.Create(new UsersAPIOptions

            {
                Endpoint = endpoint

            });
                 var sut = new UserService(httpClient,config);

            var result = await sut.GetAllUsers();

            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1)
               , ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri.ToString() == endpoint)
               , ItExpr.IsAny<CancellationToken>()
               );

            // result.Count.Should().Be(expectedResponse.Count());


        }

    }
}
