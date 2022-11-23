using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpTest.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.DeleteTest
{
        
    public class DeleteBoard : BaseTest
    {
        private string _createdBoardId;

        [SetUp]
        public void CreateBoard()
        {
            var boardName = "New BoardDelete";
            var request = RequestWithAuth(BoardsEndpoints.CreateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> {
                    { "name", boardName }
                });

            var response = _client.Post(request);
            var responseContent = JToken.Parse(response.Content);           
            _createdBoardId = responseContent.SelectToken("id").ToString();

        }

        [Test]
        public void CheckDeleteBoard()
        {
            var request = RequestWithAuth(BoardsEndpoints.DeleteBoardUrl)
                .AddUrlSegment("id", _createdBoardId);
            var response = _client.Delete(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(string.Empty, JToken.Parse(response.Content).SelectToken("_value").ToString());


            request = RequestWithAuth(BoardsEndpoints.GetAllBoardsUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("member", UrlParamValues.UserName);
            response = _client.Get(request);
            var responseContent = JToken.Parse(response.Content);

            Assert.False(responseContent.Children().Select(token => token.SelectToken("id")).Contains(_createdBoardId));

        }
    }
}
