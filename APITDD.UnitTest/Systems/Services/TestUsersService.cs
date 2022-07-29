using APITDD.UnitTest.Fixtures;
using APITDD.UnitTest.Helpers;
using APITDDSolution.API.Models;
using APITDDSolution.API.Services;
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
            
            var httpClient = new HttpClient(handlerMock.Object);

            var sut = new UserService(httpClient);

            //Act
            await sut.GetAllUsers();

            //Assert
            //verify HTTP request is made!

            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1)
                , ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get)
                , ItExpr.IsAny<CancellationToken>()
                );



        }



    }
}
