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
    public class NonAsyncHandler : BaseInvocable, IWebhookEventHandlerSync
    {
        private string SendTo { get; set; }
        public NonAsyncHandler(InvocationContext invocationContext, [WebhookParameter] RenewableParamsInput input) : base(invocationContext)
        {
            SendTo = input.SendTo;
        }

        public void Subscribe(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
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

        public void Unsubscribe(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider, Dictionary<string, string> values)
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
