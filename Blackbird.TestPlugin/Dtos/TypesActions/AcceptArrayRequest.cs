using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class AcceptArrayRequest
    {
        public IEnumerable<string> InputArrayStrings { get; set; }
    }
}
