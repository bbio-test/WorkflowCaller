using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos;
using TestPlugin.Dtos.DynamicInputActions;

namespace TestPlugin.Actions
{
    [ActionList]
    public class DynamicInputsActions
    {
        [Action("Dynamic input (required)", Description = "Dynamic input (required)")]
        public DynamicResponse DynamicRequired(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DynamicRequiredRequest input)
        {
            return new DynamicResponse() { SelectedValue =  input.DynamicInput };
        }

        [Action("Dynamic input (optional)", Description = "Dynamic input (optional)")]
        public DynamicResponse DynamicOptional(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DynamicOptionalRequest input)
        {
            return new DynamicResponse() { SelectedValue = input.DynamicInput };
        }
    }
}
