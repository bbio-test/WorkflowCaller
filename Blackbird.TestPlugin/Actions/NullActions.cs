using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos.NullActions;

namespace TestPlugin.Actions
{
    [ActionList]
    public class NullActions
    {
        [Action("Return null of types Number, Boolean, Date, Array, File, String", Description = "Return null of types Number, Boolean, Date, Array, File, String")]
        public ReturnNullTypesResponse ReturnNullTypes(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnNullTypesResponse();
        }

        [Action("Return null in nested object of types Number, Boolean, Date, Array, File", Description = "Return null in nested object of types Number, Boolean, Date, Array, File")]
        public ReturnNestedNullTypes ReturnNestedNullTypes(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnNestedNullTypes() { NestedObjectWithNulls = new ReturnNullTypesResponse() };
        }

        [Action("Return empty of types String, Array", Description = "Return empty of types String, Array")]
        public ReturnEmptyTypesResponse ReturnEmptyTypes(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnEmptyTypesResponse() { EmptyString = "", EmptyArray = new List<string>()};
        }
    }
}
