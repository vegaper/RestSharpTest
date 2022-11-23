using RestSharp;
using RestSharpTest.Arguments.Holders;
using RestSharpTest.Consts;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Arguments.Providers
{
    public class BoardIdValidationArgementsProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Object[]
            {
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "invalid id",
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    PathParams = new []{new Parameter("id", "invalidid", ParameterType.UrlSegment)}
                }

            };
            yield return new Object[]
           {
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "The requested resource was not found.",
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    PathParams = new []{new Parameter("id", "6377882b3f9e800060f41d28", ParameterType.UrlSegment)}
                }

           };
        }
    }

    public class BoardAuthValidationArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Object[]
            {
                //no token
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "unauthorized permission requested",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    PathParams = new []{new Parameter("key", UrlParamValues.Key, ParameterType.QueryString),
                                        new Parameter("id", UrlParamValues.ExistingBoardId, ParameterType.UrlSegment)}


                }

            };
            yield return new Object[]
           {
               //no key
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "unauthorized permission requested",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    PathParams = new []{new Parameter("Token", UrlParamValues.Token, ParameterType.UrlSegment),
                    new Parameter("id", UrlParamValues.ExistingBoardId, ParameterType.UrlSegment)}

                }

           };

            yield return new Object[]
          {
               //no token nor key
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "unauthorized permission requested",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    PathParams = new []{new Parameter("id", UrlParamValues.ExistingBoardId, ParameterType.UrlSegment)}
                }

          };




        }
    }

    public class CreateBoardAuthValidationArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Object[]
            {
                //no token
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "unauthorized permission requested",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    PathParams = new []{new Parameter("key", UrlParamValues.Key, ParameterType.QueryString),
                                        new Parameter("id", UrlParamValues.ExistingBoardId, ParameterType.UrlSegment)}


                }

            };
            yield return new Object[]
           {
               //no key
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "invalid key",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    PathParams = new []{new Parameter("Token", UrlParamValues.Token, ParameterType.UrlSegment),
                    new Parameter("id", UrlParamValues.ExistingBoardId, ParameterType.UrlSegment)}

                }

           };

            yield return new Object[]
          {
               //no token nor key
                new BoardsIdValidationArgumentsHolder
                {
                    ErrorMessage = "invalid key",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    PathParams = new []{new Parameter("id", UrlParamValues.ExistingBoardId, ParameterType.UrlSegment)}
                }

          };




        }
    }



}
