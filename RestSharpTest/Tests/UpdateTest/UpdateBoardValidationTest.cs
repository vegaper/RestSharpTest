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

namespace RestSharpTest.Tests.UpdateTest
{
    public class UpdateBoardValidationTest:BaseTest
    {

        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgementsProvider))]
        public void CheckUpdateBoardWithIncorrectId(BoardsIdValidationArgumentsHolder validationArguments)
        {

            var request = RequestWithAuth(BoardsEndpoints.UpdateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> { { "name", "name1" } })
                .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Put(request);

            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);       
        
        }

        [Test]
        [TestCaseSource(typeof(CreateBoardAuthValidationArgumentProvider))]
        public void CheckUpdateBoardWithInvalidAuth(BoardsIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithoutAuth(BoardsEndpoints.UpdateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> { { "name", "name1" } })
                .AddOrUpdateParameters(validationArguments.PathParams);
            var response = _client.Put(request);

            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);
        }
    }
}
