using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTest.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.CreateTest 
{
    public class CretateBoardTest : BaseTest
    {
        private string _createdBoardId;
       
        [Test]
        public void CheckCreateBoard()
        {
            var boardName = "New Board" +DateTime.Now.ToLongTimeString();
            var request = RequestWithAuth(BoardsEndpoints.CreateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> { 
                    { "name", boardName } 
                });

            var response = _client.Post(request);
            var responseContent = JToken.Parse(response.Content);
                       
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(boardName, responseContent.SelectToken("name").ToString());
            _createdBoardId = responseContent.SelectToken("id").ToString();

            request = RequestWithAuth(BoardsEndpoints.GetAllBoardsUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("member", UrlParamValues.UserName);
            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content);
           
            Assert.True(responseContent.Children().Select(token => token.SelectToken("name")).Contains(boardName));
        }

        [TearDown]
        public void DeleteCreatedBoard()
        {
            var request = RequestWithAuth(BoardsEndpoints.DeleteBoardUrl)
                .AddUrlSegment("id", _createdBoardId);
            var response = _client.Delete(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
