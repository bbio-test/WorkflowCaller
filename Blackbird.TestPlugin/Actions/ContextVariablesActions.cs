using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos.ContextVariablesActions;

namespace TestPlugin.Actions
{
    [ActionList]
    public class ContextVariablesActions : BaseInvocable
    {
        public ContextVariablesActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Return all context variables", Description = "Return all context variables")]
        public DataFromContextOutput GetContextVars()
        {
            var context = InvocationContext;
            return new DataFromContextOutput()
            {
                InvocationDate = context.InvocationDate,
                BirdId = context.Bird.Id,
                BirdName = context.Bird.Name,
                FlightId = context.Flight.Id,
                FlightUrl = context.Flight.Url,
                WorkspaceId = context.Workspace.Id,
                WorkspaceName = context.Workspace.Name,
                AuthenticationCredentialsProviders = context.AuthenticationCredentialsProviders,
                Bridge = context.UriInfo.BridgeServiceUrl.ToString(),
                AuthrozationCodeUrl = context.UriInfo.AuthorizationCodeRedirectUri.ToString(),
                ImplicitGrantUrl = context.UriInfo.ImplicitGrantRedirectUri.ToString()
            };
        }
    }
}
