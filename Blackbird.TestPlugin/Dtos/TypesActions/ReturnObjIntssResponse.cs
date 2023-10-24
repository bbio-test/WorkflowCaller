using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnObjIntssResponse
    {
        public IEnumerable<IntObj> IntsObjs { get; set; }
    }
    public class IntObj
    {
        public int x { get; set; }
    }
}
