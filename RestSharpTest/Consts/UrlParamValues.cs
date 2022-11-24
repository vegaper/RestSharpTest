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
        public const string UserName = "vickygp";
        public const string Key = "12345";
        public const string Token = "123456";
        public const string BoardIdToUpdate = "637a3614c32e9d0029313742";

        public static readonly IEnumerable<Parameter> AuthQueryParams = new[]
        {
            new Parameter("key", Key, ParameterType.QueryString),
            new Parameter("token", Token, ParameterType.QueryString)
        };

        public static readonly IEnumerable<Parameter> IncorrectUSerAuthQueryParams = new[]
        {
            new Parameter("key","123456", ParameterType.QueryString),
            new Parameter("token", "123", ParameterType.QueryString)
        };
    }
}
