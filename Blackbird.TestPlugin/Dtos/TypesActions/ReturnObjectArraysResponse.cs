using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnObjectArraysResponse
    {
        public IEnumerable<ArrayObj> Arrays { get; set; }
    }

    public class ArrayObj
    {
        public IEnumerable<string> ArrayStrings { get; set; }
    }
}
