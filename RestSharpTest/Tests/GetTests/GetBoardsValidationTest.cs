using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using RestSharp.Serializers;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Arguments.Providers;
using RestSharpTest.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.GetTests
{
    public class GetBoardValidationTest : BaseTest
    {
        //basic implementation incorrect id
        [Test]
        public void CheckGetBoardWithInvalidId()
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl)
                .AddUrlSegment("id", "1234");
            var response = _client.Get(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid id", response.Content);
        }


        //basic implementation invalid key
        [Test]
        public void CheckGetBoardWithInvalidAuth()
        {
            var request = RequestWithoutAuth(BoardsEndpoints.GetBoardUrl)
                .AddQueryParameter("Key", "invalidkey")
                .AddQueryParameter("token", "369733147d4c4d4f29f0fbb5e56307527de8c4576ea5320b79ed11bbb662e499")
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);
            var response = _client.Get(request);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.AreEqual("unauthorized permission requested", response.Content);
        }
        //basic implementation invalid token
        [Test]
        public void CheckGetBoardWithInvalidToken()
        {
            var request = RequestWithoutAuth(BoardsEndpoints.GetBoardUrl)
                .AddQueryParameter("Key", "5d3f254475ae9b62c9724b5237d40ea9")
                .AddQueryParameter("token", "1234")
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);
            var response = _client.Get(request);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.AreEqual("unauthorized permission requested", response.Content);
        }



        //correct refactor of incorrect id
        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgementsProvider))]
        public void CheckGetBoardWithInvalidId1(BoardsIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl)
                .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Get(request);
            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }

        //correct refactor of incorrect auth 
        [Test]
        [TestCaseSource(typeof(BoardAuthValidationArgumentProvider))]
        public void CheckGetBoardWithInvalidAuth(BoardsIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithoutAuth(BoardsEndpoints.GetBoardUrl)
                .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Get(request);
            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }

        [Test]      
        public void CheckGetBoardWithAnotherUserCredentials()
        {
            var request = RequestWithoutAuth(BoardsEndpoints.GetBoardUrl)
                .AddOrUpdateParameters(UrlParamValues.IncorrectUSerAuthQueryParams);
            var response = _client.Get(request);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.AreEqual("invalid key", response.Content);
        }
    }
}
