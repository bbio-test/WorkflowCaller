using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnObjDatesResponse
    {
        public IEnumerable<DateObj> DatesObjs { get; set; }
    }

    public class DateObj
    {
        public DateTime x { get; set; }
    } 
}
