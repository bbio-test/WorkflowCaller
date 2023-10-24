using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnObjectBooleansResponse
    {
        public IEnumerable<BooleanObj> BooleansObjs { get; set; }
    }

    public class BooleanObj
    {
        public bool Boolean { get; set; }
    }
}
