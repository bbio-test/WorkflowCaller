using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using TestPlugin.Webhooks.Payload;

namespace TestPlugin.Webhooks.Handlers
{
    public class AsyncHandler : BaseInvocable, IWebhookEventHandler
    {
        private string SendTo { get; set; }
        public AsyncHandler(InvocationContext invocationContext, [WebhookParameter] RenewableParamsInput input) : base(invocationContext)
        {
            SendTo = input.SendTo;
        }

        public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new RestClient();
            var request = new RestRequest(SendTo, Method.Post);
            request.AddJsonBody(new
            {
                subscription = true,
                payloadUrl = values["payloadUrl"]
            });
            client.Execute(request);
        }

        public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
        {
            var client = new RestClient();
            var request = new RestRequest(SendTo, Method.Post);
            request.AddJsonBody(new
            {
                unsubscription = true
            });
            client.Execute(request);
        }
    }
}
