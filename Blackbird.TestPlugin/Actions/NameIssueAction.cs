using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos;
using TestPlugin.Dtos.LargeFileActions;

namespace TestPlugin.Actions
{
    [ActionList]
    public class NameIssueAction
    {
        [Action("Return object with \"Name\"", Description = "Return object with \"Name\"")]
        public ReturnObjNameResponse ReturnObjName(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjNameResponse() { SomethingStr = "Test123" };
        }
    }
}
