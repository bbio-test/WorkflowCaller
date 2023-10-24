using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos;
using TestPlugin.Dtos.LargeFileActions;
using Blackbird.Applications.Sdk.Common.Files;

namespace TestPlugin.Actions
{
    [ActionList]
    public class LargeFileActions : BaseInvocable
    {
        public LargeFileActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("Download file by url and return ref to file", Description = "Download file by url and return ref to file")]
        public FileRefResponse DownloadFileAndGetRef([ActionParameter] DownloadFileAndGetRefRequest input)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, input.DownloadUrl);
            var fileReference = new FileReference(httpRequestMessage);
            fileReference.Name = "Testfile";
            fileReference.ContentType = MediaTypeNames.Application.Octet;
            return new FileRefResponse
            {
                Name = fileReference.Name,
                FileReference = fileReference
            };
        }

        [Action("Get download url and return url", Description = "Get download url and return url")]
        public string GetDownloadUrlFromFileReference([ActionParameter] FileRefRequest input)
        {
            return input.FileReference.DownloadUrl;
        }
    }
}
