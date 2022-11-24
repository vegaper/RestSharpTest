using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using RestSharp.Serializers;
using RestSharpTest.Consts;
using RestSharpTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Tests.GetTests
{
    public class GetBoardTest : BaseTest
    {
        [Test]
        public void CheckGetBoards()
        {
            var request = RequestWithAuth(BoardsEndpoints.GetAllBoardsUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("member", UrlParamValues.UserName);

            var response = _client.Get(request);

            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_boards.json"));
            Assert.True(responseContent.IsValid(jsonSchema));
        }


        [Test]
        public void CheckGetBoard()
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);

            var response = _client.Get(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString(), Is.EqualTo("newname"));

        }

        [Test]
        public void CheckGetBoardDeserial()
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardUrl)
                .AddQueryParameter("field", "id,name")
                .AddUrlSegment("id", UrlParamValues.ExistingBoardId);

            var response = _client.Get<Board>(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(response.Data.name, Is.EqualTo("newname"));

        }

    }
}
