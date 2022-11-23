using RestSharp;
using RestSharpTest.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest
{
    public class BaseTest
    {
        protected static IRestClient _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() =>
           _client = new RestClient("https://api.trello.com");


        protected IRestRequest RequestWithAuth(string url) =>

            //new RestRequest(url)
            //   .AddQueryParameter("key", UrlParamValues.Key)
            //   .AddQueryParameter("token", UrlParamValues.Token);

            new RestRequest(url)
            .AddOrUpdateParameters(UrlParamValues.AuthQueryParams);
       
        protected IRestRequest RequestWithoutAuth(string url) =>       
             new RestRequest(url);
                       

    }

}
