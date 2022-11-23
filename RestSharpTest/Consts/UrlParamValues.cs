using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Consts
{
    public class UrlParamValues
    {
        public const string ExistingBoardId = "6377882b3f9e800060f41d29";
        public const string UserName = "vicky";
        public const string Key = "50000000000000ea8";
        public const string Token = "300000000000000000000000000000000000000000000008";
        public const string BoardIdToUpdate = "637a3614c32e9d0029313742";

        public static readonly IEnumerable<Parameter> AuthQueryParams = new[]
        {
            new Parameter("key", Key, ParameterType.QueryString),
            new Parameter("token", Token, ParameterType.QueryString)
        };

        public static readonly IEnumerable<Parameter> IncorrectUSerAuthQueryParams = new[]
        {
            new Parameter("key","5d3f254475ae9b62c9724b5237d40ea8", ParameterType.QueryString),
            new Parameter("token", "369733147d4c4d4f29f0fbb5e56307527de8c4576ea5320b79ed11bbb662e499", ParameterType.QueryString)
        };
    }
}
