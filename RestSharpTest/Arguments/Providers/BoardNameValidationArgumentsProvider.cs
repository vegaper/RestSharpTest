using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.Arguments.Providers
{
    public class BoardNameValidationArgumentsProvider : IEnumerable
    {
       

        IEnumerator IEnumerable.GetEnumerator()
        {
            //invalid data type
            yield return new object[]
            {
                new Dictionary<string, object> {{"name", 123456}}
            };
            //no parameters
            yield return new object[]
            {
                ImmutableDictionary<string, object>.Empty
            };
        }
    }
}
