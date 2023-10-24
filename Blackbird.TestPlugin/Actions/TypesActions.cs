using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos.NestedActions;
using TestPlugin.Dtos.TypesActions;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace TestPlugin.Actions
{
    [ActionList]
    public class TypesActions
    {
        [Action("Return all types Number, Boolean, Date, Array, File", Description = "Return all types Number, Boolean, Date, Array, File")]
        public AllTypesResponse ReturnAllTypes(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return CreateAllTypesObject("some string 1", 1, true, DateTime.Now, NestedActions.FileExample);
        }

        [Action("Accept text - return all (text mirrored)", Description = "Accept text - return all (text mirrored)")]
        public AllTypesResponse AcceptText(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, 
            [ActionParameter] AcceptTextRequest input)
        {
            return CreateAllTypesObject(input.InputText, 1, true, DateTime.Now, NestedActions.FileExample);
        }

        [Action("Accept number - return all (number mirrored)", Description = "Accept number - return all (number mirrored)")]
        public AllTypesResponse AcceptNumber(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AcceptNumberRequest input)
        {
            return CreateAllTypesObject("some string 1", input.InputNumber, true, DateTime.Now, NestedActions.FileExample);
        }

        [Action("Accept boolean - return all (boolean mirrored)", Description = "Accept boolean - return all (boolean mirrored)")]
        public AllTypesResponse AcceptBoolean(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AcceptBooleanRequest input)
        {
            return CreateAllTypesObject("some string 1", 1, input.InputBoolean, DateTime.Now, NestedActions.FileExample);
        }

        [Action("Accept date - return all (date mirrored)", Description = "Accept date - return all (date mirrored)")]
        public AllTypesResponse AcceptDate(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AcceptDateRequest input)
        {
            return CreateAllTypesObject("some string 1", 1, true, input.InputDate, NestedActions.FileExample);
        }

        [Action("Accept array - return all", Description = "Accept array - return all")]
        public AllTypesResponse AcceptArray(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AcceptArrayRequest input)
        {
            return CreateAllTypesObject("some string 1", 1, true, DateTime.Now, NestedActions.FileExample);
        }

        [Action("Accept file - return all (file mirrored)", Description = "Accept file - return all (file mirrored)")]
        public AllTypesResponse AcceptFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AcceptFileRequest input)
        {
            return CreateAllTypesObject("some string 1", 1, true, DateTime.Now, input.File);
        }

        [Action("Convert string to number", Description = "Convert string to number")]
        public ConvertStringResponse ConverString(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AcceptTextRequest input)
        {
            return new ConvertStringResponse{ OutputNumber = int.Parse(input.InputText) };
        }

        [Action("Return array of simple float numbers", Description = "Return array of simple float numbers")]
        public ReturnFloatsResponse ReturnFloats(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnFloatsResponse()
            {
                FloatNumbers = new List<float>() { 0.1f, 0.2f, 0.3f, 0.4f, 0.5f }
            };
        }

        [Action("Return array of simple int numbers", Description = "Return array of simple int numbers")]
        public ReturnIntssResponse ReturnInts(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnIntssResponse()
            {
                IntNumbers = new List<int>() { 1, 2, 3, 4, 5 }
            };
        }

        [Action("Return array of simple strings", Description = "Return array of simple strings")]
        public ReturnStringsResponse ReturnStrings(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnStringsResponse()
            {
                Strings = new List<string>() { "str 1", "str 2", "str 3", "str 4", "str 5" }
            };
        }

        [Action("Return array of simple dates", Description = "Return array of simple dates")]
        public ReturnDatesResponse ReturnDates(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnDatesResponse()
            {
                Dates = new List<DateTime>() { DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), DateTime.Now.AddDays(3), DateTime.Now.AddDays(4) }
            };
        }

        [Action("Return array of simple files", Description = "Return array of simple files")]
        public ReturnFilesResponse ReturnFiles(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnFilesResponse()
            {
                Files = new List<File>() { new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File1"  },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File2" },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File3" },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File4" },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File5" }}
            };
        }

        [Action("Return array of simple booleans", Description = "Return array of simple booleans")]
        public ReturnBooleansResponse ReturnBooleans(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnBooleansResponse()
            {
                Booleans = new List<bool>() { true, false, true, false, true }
            };
        }

        [Action("Return array of simple arrays (with strings)", Description = "Return array of simple arrays (with strings)")]
        public ReturnArraysResponse ReturnArrays(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnArraysResponse()
            {
                Arrays = new List<List<string>>() { new List<string>() { "array1_1", "array1_2" },
                                                    new List<string>() { "array2_1", "array2_2" },
                                                    new List<string>() { "array3_1", "array3_2" },
                                                    new List<string>() { "array4_1", "array4_2" },
                                                    new List<string>() { "array5_1", "array5_2" }
                }
            };
        }

        [Action("Return array of objects with float numbers", Description = "Return array of objects with float numbers")]
        public ReturnObjFloatsResponse ReturnObjFloats(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjFloatsResponse()
            {
                FloatsObjs = new List<FloatObj>() { new FloatObj() { x = 0.1f}, new FloatObj() { x = 0.2f }, new FloatObj() { x = 0.3f },
                new FloatObj() { x = 0.4f}, new FloatObj() { x = 0.5f}}
            };
        }

        [Action("Return array of objects with int numbers", Description = "Return array of objects with int numbers")]
        public ReturnObjIntssResponse ReturnObjInts(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjIntssResponse()
            {
                IntsObjs = new List<IntObj>() { new IntObj() { x = 1 }, new IntObj() { x = 2 }, new IntObj() { x = 3 },
                new IntObj() { x = 4 }, new IntObj() { x = 5 }}
            };
        }

        [Action("Return array of objects with strings", Description = "Return array of objects with strings")]
        public ReturnObjStringsResponse ReturnObjStrings(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjStringsResponse()
            {
                StringsObjs = new List<StringObj>() {new StringObj() { x = "str 1" }, new StringObj() { x = "str 2" }, new StringObj() { x = "str 3" },
                new StringObj() { x = "str 4" }, new StringObj() { x = "str 5" } }
            };
        }

        [Action("Return array of objects with dates", Description = "Return array of objects with dates")]
        public ReturnObjDatesResponse ReturnObjDates(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjDatesResponse()
            {
                DatesObjs = new List<DateObj>() { new DateObj() { x = DateTime.Now }, new DateObj() { x = DateTime.Now.AddDays(1) }, new DateObj() { x = DateTime.Now.AddDays(2) },
                new DateObj() { x = DateTime.Now.AddDays(3) }, new DateObj() { x = DateTime.Now.AddDays(4) } }
            };
        }

        [Action("Return array of objects with files", Description = "Return array of objects with files")]
        public ReturnObjectFilesResponse ReturnObjectFiles(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjectFilesResponse()
            {
                FilesObjs = new List<File>() { new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File1"  },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File2" },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File3" },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File4" },
                                                  new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet, Name = "File5" }
                }
            };
        }

        [Action("Return array of objects with booleans", Description = "Return array of objects with booleans")]
        public ReturnObjectBooleansResponse ReturnObjectBooleans(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjectBooleansResponse()
            {
                BooleansObjs = new List<BooleanObj>() { new BooleanObj() { Boolean = true }, new BooleanObj() { Boolean = false }, new BooleanObj() { Boolean = true },
                new BooleanObj() { Boolean = false }, new BooleanObj() { Boolean = true }}
            };
        }

        [Action("Return array of objects with arrays", Description = "Return array of objects with arrays")]
        public ReturnObjectArraysResponse ReturnObjectArrays(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            return new ReturnObjectArraysResponse()
            {
                Arrays = new List<ArrayObj>() { new ArrayObj { ArrayStrings = new List<string>() { "array1_1", "array1_2" } }, 
                                                new ArrayObj { ArrayStrings = new List<string>() { "array2_1", "array2_2" } },
                                                new ArrayObj { ArrayStrings = new List<string>() { "array3_1", "array3_2" } },
                                                new ArrayObj { ArrayStrings = new List<string>() { "array4_1", "array4_2" } },
                                                new ArrayObj { ArrayStrings = new List<string>() { "array5_1", "array5_2" } }
                }
            };
        }

        private AllTypesResponse CreateAllTypesObject(string inputStr, double inputD, bool inputBool, DateTime inputDateTime, byte[] inputFile)
        {
            return new AllTypesResponse()
            {
                SomeString = inputStr,
                SomeNumber = inputD,
                SomeBoolean = true,
                SomeDate = inputDateTime,
                SomeFile = new File(NestedActions.FileExample) { ContentType = MediaTypeNames.Application.Octet , Name = "File" } ,
                SomeArray = new List<ArrayItem>() { new ArrayItem(1), new ArrayItem(2), new ArrayItem(3) }
            };
        }
    }
}
