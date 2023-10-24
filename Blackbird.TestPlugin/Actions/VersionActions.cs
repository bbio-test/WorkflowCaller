using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos.DifferentVersionActions;
using TestPlugin.Dtos.TypesActions;

namespace TestPlugin.Actions
{
    [ActionList]
    public class VersionActions
    {
        [Action("Action for different versions", Description = "Accept text - return all (text mirrored)")]
        public ActionForDifferentVersionResponse ActionForDifferentVersion(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AcceptTextRequest input)
        {
            return new ActionForDifferentVersionResponse() { Output1 = input.InputText, Output2 = new Random().Next()};
        }

        [Action("Action for different versions 2", Description = "Action for different versions 2")]
        public ActionForDifferentVersionResponse ActionForDifferentVersion2(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] ActionForDifVersionRequest input)
        {
            return new ActionForDifferentVersionResponse() { Output1 = "test version 2" };
        }
    }
}
