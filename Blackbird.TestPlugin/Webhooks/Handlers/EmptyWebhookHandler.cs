using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Webhooks.Handlers
{
    public class EmptyWebhookHandler : IWebhookEventHandler
    {
        private string SubscriptionEvent { get; set; }

        private string RepositoryId { get; set; }

        public EmptyWebhookHandler()
        {
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                Dictionary<string, string> values)
        {

        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            Dictionary<string, string> values)
        {
        }
    }
}
