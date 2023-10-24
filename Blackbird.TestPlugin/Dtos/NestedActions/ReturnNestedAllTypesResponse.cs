using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;


namespace TestPlugin.Dtos.NestedActions
{
    public class ReturnNestedAllTypesResponse
    {
        public NestedObject NestedObject { get; set; }
    }

    public class NestedObject
    {
        public string SomeString { get; set; }

        public int SomeNumber { get; set; }

        public bool SomeBoolean { get; set; }

        public DateTime SomeDate { get; set; }

        public IEnumerable<ArrayItem> SomeArray { get; set; }

        public File SomeFile { get; set; }
    }

    public class ArrayItem
    {
        public ArrayItem(int arrNumber)
        {
            SomeArrayItemNumber = arrNumber;
            SomeArrayItemBoolean = true;
            SomeArrayItemDate = DateTime.Now;
            SomeArrayItemString = "array item";
        }

        public int SomeArrayItemNumber { get; set; }

        public bool SomeArrayItemBoolean { get; set; }

        public DateTime SomeArrayItemDate { get; set; }

        public string SomeArrayItemString { get; set; }
    }
}
