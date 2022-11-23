using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Arguments.Providers;
using RestSharpTest.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static RestSharpTest.Arguments.Providers.BoardAuthValidationArgumentProvider;

namespace RestSharpTest.Tests.CreateTest
{
    internal class CreateBoardValidationTest: BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BoardNameValidationArgumentsProvider))]
        public void CheckCreateBoardWithInvalidName(IDictionary<string, object> bodyParams)
        {
            var request = RequestWithAuth(BoardsEndpoints.CreateBoardUrl)
                .AddJsonBody(bodyParams);

            var response = _client.Post(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid value for name", response.Content);


        }

        [Test]
        [TestCaseSource(typeof(CreateBoardAuthValidationArgumentProvider))]
        public void CheckGetBoardWithInvalidAuth(BoardsIdValidationArgumentsHolder validationArguments)
        {
            var boardName = "New Board" ;  

            var request = RequestWithoutAuth(BoardsEndpoints.CreateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> {
                    { "name", boardName }
                })
                .AddOrUpdateParameters(validationArguments.PathParams);

            
            var response = _client.Post(request);

            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }

    }
}
