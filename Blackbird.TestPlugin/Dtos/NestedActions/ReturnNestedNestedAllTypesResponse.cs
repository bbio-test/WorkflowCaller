using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.NestedActions
{
    public class ReturnNestedNestedAllTypesResponse
    {
        public NestedObject1 NestedObject1 { get; set; }
    }

    public class NestedObject1
    {
        public NestedObject NestedObject2 { get; set; }
    }
}
