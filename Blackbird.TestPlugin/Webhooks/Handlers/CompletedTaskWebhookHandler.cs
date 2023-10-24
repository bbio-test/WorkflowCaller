using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Webhooks.Handlers
{
    public class CompletedTaskWebhookHandler : IWebhookEventHandler
    {
        private string SubscriptionEvent { get; set; }

        private string RepositoryId { get; set; }

        public CompletedTaskWebhookHandler()
        {
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                Dictionary<string, string> values)
        {
            await Task.CompletedTask;
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            Dictionary<string, string> values)
        {
            await Task.CompletedTask;
        }
    }
}
