using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnArraysResponse
    {
        public IEnumerable<List<string>> Arrays { get; set; }
    }
}
