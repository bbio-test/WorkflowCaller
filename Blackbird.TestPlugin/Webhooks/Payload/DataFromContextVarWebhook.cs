using Blackbird.Applications.Sdk.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Webhooks.Responses
{
    public class DataFromContextVarWebhook
    {
        public DateTime InvocationDate { get; set; }

        public long WorkspaceId { get; set; }

        public string WorkspaceName { get; set; }

        public long BirdId { get; set; }

        public string BirdName { get; set; }

        public IEnumerable<AuthenticationCredentialsProvider> AuthenticationCredentialsProviders { get; set; }
    }
}
