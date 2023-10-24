using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Connections
{
    public class ConnectionChecker : IConnectionValidator
    {
        public ValueTask<ConnectionValidationResponse> ValidateConnection(IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
        {
            var validation = authProviders.FirstOrDefault(key => key.KeyName == "connectionValidation").Value;
            var client = new RestClient();
            var request = new RestRequest(validation, Method.Post);
            request.AddJsonBody(new
            {
                ping = "ping connection"
            });

            var pingRes = client.Execute(request);
            var result = new ConnectionValidationResponse()
            {
                IsValid = pingRes.IsSuccessful,
                Message = pingRes.IsSuccessful ? "Success" : "Failed ping"
            };
            return new ValueTask<ConnectionValidationResponse>(result);
        }
    }
}
