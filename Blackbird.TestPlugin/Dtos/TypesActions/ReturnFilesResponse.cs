using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnFilesResponse
    {
        public IEnumerable<File> Files { get; set; }
    }
}
