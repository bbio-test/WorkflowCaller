using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnObjStringsResponse
    {
        public IEnumerable<StringObj> StringsObjs { get; set; }

    }

    public class StringObj
    {
        public string x { get; set; }
    }
}
