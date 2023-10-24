using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.NestedActions
{
    public class ReturnArrayNestedAllTypessResponse
    {
        public IEnumerable<ReturnNestedAllTypesResponse> NestedObjects { get; set; }
    }
}
