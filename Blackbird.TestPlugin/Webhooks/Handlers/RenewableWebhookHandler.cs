using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Webhooks.Payload;

namespace TestPlugin.Webhooks.Handlers
{
    public class RenewableWebhookHandler : BaseInvocable, IWebhookEventHandler, IAsyncRenewableWebhookEventHandler
    {
        private string SendTo { get; set; }
        public RenewableWebhookHandler(InvocationContext invocationContext, [WebhookParameter] RenewableParamsInput input) : base(invocationContext)
        {
            SendTo = input.SendTo;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                Dictionary<string, string> values)
        {
            var client = new RestClient();
            var request = new RestRequest(SendTo, Method.Post);
            request.AddJsonBody(new
            {
                subscription = true,
                payloadUrl = values["payloadUrl"]
            });
            await client.ExecuteAsync(request);
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            Dictionary<string, string> values)
        {
            var client = new RestClient();
            var request = new RestRequest(SendTo, Method.Post);
            request.AddJsonBody(new
            {
                unsubscription = true
            });
            await client.ExecuteAsync(request);
        }

        [Period(1)]
        public async Task RenewSubscription(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new RestClient();
            var request = new RestRequest(SendTo, Method.Post);
            request.AddJsonBody(new
            {
                renewableSubscription = true
            });
            await client.ExecuteAsync(request);
        }

    }
}
