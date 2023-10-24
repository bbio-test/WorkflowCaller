using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnObjFloatsResponse
    {
        public IEnumerable<FloatObj> FloatsObjs { get; set; }
    }

    public class FloatObj {

        public float x { get; set; }

    }

}
