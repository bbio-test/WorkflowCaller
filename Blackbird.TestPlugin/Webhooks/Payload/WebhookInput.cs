using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Webhooks.Payload
{
    public class WebhookInput
    {
        [Display("Url for subscription")]
        public string UrlToSendSubscription { get; set; }
    }
}
