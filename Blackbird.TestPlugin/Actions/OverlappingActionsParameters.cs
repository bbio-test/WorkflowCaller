using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos.OverlappingActionsParameters;
using TestPlugin.Dtos.TypesActions;

namespace TestPlugin.Actions
{
    [ActionList]
    public class OverlappingActionsParameters
    {
        [Action("Overlapping user id", Description = "Overlapping user id")]
        public OverlapOutput OverlapTest(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] OverlapInput input)
        {
            return new OverlapOutput() {
                UserId = input.UserId,
                SomeString = input.UserId,
                TenId = input.TenantId,
                WorkId = input.WorkspaceId
            };
        }
    }
}
