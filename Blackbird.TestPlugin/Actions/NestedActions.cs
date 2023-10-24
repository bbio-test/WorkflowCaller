using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Actions;
using TestPlugin.Dtos.NestedActions;
using System.Net.Mime;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace TestPlugin.Actions
{
    [ActionList]
    public class NestedActions
    {
        public static byte[] FileExample = new byte[] {0x48, 0x69, 0x2C, 0x20, 0x6E, 0x69, 0x63, 0x65, 0x20, 0x74, 0x6F, 0x20, 0x6D, 0x65, 0x65, 0x74, 0x20, 0x79, 0x6F, 0x75};

        [Action("Return nested object with Number, Boolean, Date, Array, File fields", Description = "Return nested object with Number, Boolean, Date, Array, File fields")]
        public ReturnNestedAllTypesResponse ReturnNestedAllTypes(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var result = new ReturnNestedAllTypesResponse()
            {
                NestedObject = CreateNestedObject("some string 1", 1)
            };
            return result;
        }

        [Action("Return array with nested objects with Number, Boolean, Date, Array, File fields", Description = "Return array with nested objects with Number, Boolean, Date, Array, File fields")]
        public ReturnArrayNestedAllTypessResponse ReturnArrayNestedAllTypes(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var result = new ReturnNestedAllTypesResponse()
            {
                NestedObject = CreateNestedObject("some string 1", 1)
            };
            var result2 = new ReturnNestedAllTypesResponse()
            {
                NestedObject = CreateNestedObject("some string 2", 2)
            };
            return new ReturnArrayNestedAllTypessResponse() { NestedObjects = new List<ReturnNestedAllTypesResponse>() { result, result2 } };
        }

        [Action("Return nested object in nested object with Number, Boolean, Date, Array, File, String fields", Description = "Return nested object in nested object with Number, Boolean, Date, Array, File, String fields")]
        public ReturnNestedNestedAllTypesResponse ReturnNestedNestedAllTypes(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var result = new ReturnNestedNestedAllTypesResponse()
            {
                NestedObject1 = new NestedObject1()
                {
                    NestedObject2 = CreateNestedObject("some string 1", 1)
                }
            };
            return result;
        }

        private NestedObject CreateNestedObject(string inputStr, int inputInt)
        {
            return new NestedObject()
            {
                SomeString = inputStr,
                SomeNumber = inputInt,
                SomeBoolean = true,
                SomeDate = DateTime.Now,
                SomeFile = new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File.txt" },
                SomeArray = new List<ArrayItem>() { new ArrayItem(1), new ArrayItem(2), new ArrayItem(3) }
            };
        }
    }
}
