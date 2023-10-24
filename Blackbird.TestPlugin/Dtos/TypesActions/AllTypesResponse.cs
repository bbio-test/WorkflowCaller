using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos.NestedActions;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace TestPlugin.Dtos.TypesActions
{
    public class AllTypesResponse
    {
        public string SomeString { get; set; }

        public double SomeNumber { get; set; }

        public bool SomeBoolean { get; set; }

        public DateTime SomeDate { get; set; }

        public IEnumerable<ArrayItem> SomeArray { get; set; }

        public File SomeFile { get; set; }
    }
}
