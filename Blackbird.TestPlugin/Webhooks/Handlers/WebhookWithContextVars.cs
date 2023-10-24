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
using TestPlugin.Webhooks.Responses;

namespace TestPlugin.Webhooks.Handlers
{
    public class WebhookWithContextVars : BaseInvocable, IWebhookEventHandler
    {
        private string _webhookSubscriptionUrl;
        public WebhookWithContextVars(InvocationContext invocationContext, [WebhookParameter] WebhookInput input) : base(invocationContext)
        {
            _webhookSubscriptionUrl = input.UrlToSendSubscription;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new RestClient();
            var request = new RestRequest(_webhookSubscriptionUrl, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                payloadUrl = values["payloadUrl"],
                InvocationDate = InvocationContext.InvocationDate,
                BirdId = InvocationContext.Bird.Id,
                BirdName = InvocationContext.Bird.Name,
                WorkspaceId = InvocationContext.Workspace.Id,
                WorkspaceName = InvocationContext.Workspace.Name,
                AuthenticationCredentialsProviders = InvocationContext.AuthenticationCredentialsProviders
            });
            await client.ExecuteAsync(request);
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new RestClient();
            var request = new RestRequest(_webhookSubscriptionUrl, Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                status = "Unsubscribed"
            });
            await client.ExecuteAsync(request);
        }
    }
}
