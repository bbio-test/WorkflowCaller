using Blackbird.Applications.Sdk.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.ContextVariablesActions
{
    public class DataFromContextOutput
    {
        public DateTime InvocationDate { get; set; }

        public long WorkspaceId { get; set; }

        public string WorkspaceName { get; set; }

        public long BirdId { get; set; }

        public string BirdName { get; set; }

        public Guid FlightId { get; set; }

        public string FlightUrl { get; set; }

        public IEnumerable<AuthenticationCredentialsProvider> AuthenticationCredentialsProviders { get; set; }

        public string Bridge { get; set; }
        public string AuthrozationCodeUrl { get; set; }
        public string ImplicitGrantUrl { get; set; }
    }
}
