using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTest.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.UpdateTest
{
    public class UpdateBoardTest: BaseTest
    {
        [Test]
        public void CheckUpdateBoard()
        {
            var updatedName = "name" + DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(BoardsEndpoints.UpdateBoardUrl)
                .AddUrlSegment("id", UrlParamValues.BoardIdToUpdate)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });
            var response = _client.Put(request);
            var responseContent = JToken.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(updatedName, responseContent.SelectToken("name").ToString());

            request = RequestWithAuth(BoardsEndpoints.GetBoardUrl)
                .AddUrlSegment("id", UrlParamValues.BoardIdToUpdate);
            response = _client.Get(request);    
            responseContent = JToken.Parse(response.Content);
            Assert.AreEqual(updatedName, responseContent.SelectToken("name").ToString());
        }
    }
}
