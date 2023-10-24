
using TestPlugin.Webhooks.Responses;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using TestPlugin.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using TestPlugin.Dtos.DynamicInputActions;
using TestPlugin.Dtos.NestedActions;
using TestPlugin.Actions;
using TestPlugin.Webhooks.Payload;
using File = Blackbird.Applications.Sdk.Common.Files.File;
using System.Net.Mime;

namespace TestPlugin.Webhooks
{
    [WebhookList]
    public class TestWebhooks : BaseInvocable
    {
        public TestWebhooks(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Webhook("On webhook manual invoke", Description = "On webhook manual invoke")]
        public async Task<WebhookResponse<TestResponse>> IssueUpdated(WebhookRequest request)
        {
            var data = JsonConvert.DeserializeObject<TestResponse>(request.Body.ToString());
            return new WebhookResponse<TestResponse>
            {
                HttpResponseMessage = null,
                Result = new TestResponse
                {
                    TestString = data.TestString,
                    TestDate = data.TestDate,
                }
            };
        }

        [Webhook("On webhook unsubscription fail", typeof(BaseWebhookHandler), Description = "On webhook unsubscription fail")]
        public async Task<WebhookResponse<TestResponse>> UnsubscribeFail(WebhookRequest request)
        {
            
            return new WebhookResponse<TestResponse>
            {
                HttpResponseMessage = null,
                Result = new TestResponse
                {
                    TestString = "test",
                    TestDate = DateTime.Now,
                }
            };
        }

        [Webhook("On webhook with context vars (subscription)", typeof(WebhookWithContextVars), Description = "On webhook with context vars (subscription)")]
        public async Task<WebhookResponse<DataFromContextVarWebhook>> ContextVarsWebhookSub(WebhookRequest request)
        {
            var context = InvocationContext;
            return new WebhookResponse<DataFromContextVarWebhook>
            {
                HttpResponseMessage = null,
                Result = new DataFromContextVarWebhook
                {
                    InvocationDate = context.InvocationDate,
                    BirdId = context.Bird.Id,
                    BirdName = context.Bird.Name,
                    WorkspaceId = context.Workspace.Id,
                    WorkspaceName = context.Workspace.Name,
                    AuthenticationCredentialsProviders = context.AuthenticationCredentialsProviders
                }
            };
        }

        [Webhook("On webhook with context vars (manual)", Description = "On webhook with context vars (manual)")]
        public async Task<WebhookResponse<DataFromContextVarWebhook>> ContextVarsWebhookManual(WebhookRequest request)
        {
            var context = InvocationContext;
            return new WebhookResponse<DataFromContextVarWebhook>
            {
                HttpResponseMessage = null,
                Result = new DataFromContextVarWebhook
                {
                    InvocationDate = context.InvocationDate,
                    BirdId = context.Bird.Id,
                    BirdName = context.Bird.Name,
                    WorkspaceId = context.Workspace.Id,
                    WorkspaceName = context.Workspace.Name,
                    AuthenticationCredentialsProviders = context.AuthenticationCredentialsProviders
                }
            };
        }

        [Webhook("On webhook with nested (manual)", Description = "On webhook with nested (manual)")]
        public async Task<WebhookResponse<ReturnNestedAllTypesResponse>> NestedManual(WebhookRequest request)
        {
            var context = InvocationContext;
            var result = new ReturnNestedAllTypesResponse()
            {
                NestedObject = CreateNestedObject("some string 1", 1)
            };
            return new WebhookResponse<ReturnNestedAllTypesResponse>
            {
                HttpResponseMessage = null,
                Result = result
            };
        }

        [Webhook("On webhook with dynamic input (required)", Description = "On webhook with dynamic input (required)")]
        public async Task<WebhookResponse<DynamicResponse>> DynamicRequired(WebhookRequest request, [WebhookParameter] DynamicRequiredRequest input)
        {
            return new WebhookResponse<DynamicResponse>
            {
                HttpResponseMessage = null,
                Result = new DynamicResponse
                {
                    SelectedValue = input.DynamicInput
                }
            };
        }

        [Webhook("On webhook with dynamic input (optional)", Description = "On webhook with dynamic input (optional)")]
        public async Task<WebhookResponse<DynamicResponse>> DynamicOptional(WebhookRequest request, [WebhookParameter] DynamicOptionalRequest input)
        {
            return new WebhookResponse<DynamicResponse>
            {
                HttpResponseMessage = null,
                Result = new DynamicResponse
                {
                    SelectedValue = input.DynamicInput
                }
            };
        }

        [Webhook("On webhook with query params", Description = "On webhook with query params")]
        public async Task<WebhookResponse<OnQueryParamsResponse>> OnQueryParams(WebhookRequest request)
        {
            
            return new WebhookResponse<OnQueryParamsResponse>
            {
                HttpResponseMessage = null,
                Result = new OnQueryParamsResponse
                {
                    Parameter1 = request.QueryParameters["Parameter1"],
                    Parameter2 = request.QueryParameters["Parameter2"],
                    Parameter3 = request.QueryParameters["Parameter3"]
                }
            };
        }

        [Webhook("On renewable webhook", typeof(RenewableWebhookHandler), Description = "On renewable webhook")]
        public async Task<WebhookResponse<TestResponse>> RenewableWebhook(WebhookRequest request)
        {

            return new WebhookResponse<TestResponse>
            {
                HttpResponseMessage = null,
                Result = new TestResponse
                {
                    TestString = "test",
                    TestDate = DateTime.Now,
                }
            };
        }

        [Webhook("On sync webhook", typeof(NonAsyncHandler), Description = "On sync webhook")]
        public async Task<WebhookResponse<TestResponse>> SyncWebhook(WebhookRequest request)
        {
            return new WebhookResponse<TestResponse>
            {
                HttpResponseMessage = null,
                Result = new TestResponse
                {
                    TestString = "test",
                    TestDate = DateTime.Now,
                }
            };
        }

        [Webhook("On async webhook", typeof(AsyncHandler), Description = "On async webhook")]
        public async Task<WebhookResponse<TestResponse>> AsyncWebhook(WebhookRequest request)
        {
            return new WebhookResponse<TestResponse>
            {
                HttpResponseMessage = null,
                Result = new TestResponse
                {
                    TestString = "test",
                    TestDate = DateTime.Now,
                }
            };
        }

        [Webhook("On different versions webhook", typeof(AsyncHandler), Description = "On different versions webhook")]
        public async Task<WebhookResponse<TestResponse>> AsyncWebhookVersion(WebhookRequest request)
        {
            return new WebhookResponse<TestResponse>
            {
                HttpResponseMessage = null,
                Result = new TestResponse
                {
                    TestString = "test1",
                    TestDate = DateTime.Now,
                }
            };
        }

        private NestedObject CreateNestedObject(string inputStr, int inputInt)
        {
            return new NestedObject()
            {
                SomeString = inputStr,
                SomeNumber = inputInt,
                SomeBoolean = true,
                SomeDate = DateTime.Now,
                SomeFile = new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File1" },
                SomeArray = new List<ArrayItem>() { new ArrayItem(1), new ArrayItem(2), new ArrayItem(3) }
            };
        }
    }
}