using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.Dtos.LargeFileActions
{
    public class FileRefResponse
    {
        public string Name { get; set; }
        public FileReference FileReference { get; set; }
    }
}
