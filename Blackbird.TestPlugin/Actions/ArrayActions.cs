using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using TestPlugin.Dtos;
using TestPlugin.Dtos.ArrayActions;

namespace TestPlugin.Actions
{
    [ActionList]
    public class ArrayActions
    {
        [Action("Get array with 2 string elements", Description = "Get array with 2 string elements")]
        public TestAcceptArrayRequest ReturnArray(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new TestAcceptArrayRequest() { Testing = new List<string>() { "first", "second" } };
        }

        [Action("Accept array with strings and return last value", Description = "Accept array with strings and return last value")]
        public TestAcceptArrayResponse AcceptArray(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] TestAcceptArrayRequest2 input)
        {
            return new TestAcceptArrayResponse() { FirstArrayValue = input.StringArray2.Last() };
        }

        [Action("Get array with 2 float elements", Description = "Get array with 2 float elements")]
        public TestAcceptFloatArrayResponse ReturnFloatArray(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new TestAcceptFloatArrayResponse() { Floats = new List<float>() { 0.1f, -0.1f, -0.2f, 0.2f } };
        }

        [Action("Accept array with floats and return last value", Description = "Accept array with floats and return last value")]
        public float AcceptFloatArray(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] TestAcceptFloatArrayResponse2 input)
        {
            return input.Vector.Last();
        }
    }
}
