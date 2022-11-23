using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Arguments.Providers;
using RestSharpTest.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.DeleteTest
{
    public class DeleteBoardValidationTests:BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgementsProvider))]
        public void CheckDeleteBoardWithInvalidId(BoardsIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth(BoardsEndpoints.DeleteBoardUrl)
                .AddOrUpdateParameters(validationArguments.PathParams);

            var response = _client.Delete(request); 
            Assert.AreEqual(validationArguments.StatusCode, response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage, response.Content);

        }

        [Test] 
        [TestCaseSource(typeof(CreateBoardAuthValidationArgumentProvider))]
        public void CheckDeleteBoardWithInvalidCredentials(BoardsIdValidationArgumentsHolder validationArguments )
        {
            var request = RequestWithoutAuth(BoardsEndpoints.DeleteBoardUrl)
                .AddOrUpdateParameters(validationArguments.PathParams)
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);

            var response = _client.Delete(request);
            Assert.AreEqual(validationArguments.StatusCode,response.StatusCode);
            Assert.AreEqual(validationArguments.ErrorMessage,response.Content); 


        }
    }
}
