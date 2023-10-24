using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.Dtos.NestedActions;

namespace TestPlugin.Dtos.NullActions
{
    public class ReturnNullTypesResponse
    {
        public ReturnNullTypesResponse()
        {
            NullNumber = null;
            NullBoolean = null;
            NullDate = null;
            NullArray = null;
            NullFile = null;
            NullString = null;
        }

        public int? NullNumber { get; set; }

        public string NullString { get; set; }

        public bool? NullBoolean { get; set; }

        public DateTime? NullDate { get; set; }

        public IEnumerable<ArrayItem> NullArray { get; set; }

        public byte[] NullFile { get; set; }
    }
}
