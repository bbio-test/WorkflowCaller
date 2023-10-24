using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace TestPlugin.Dtos.TypesActions
{
    public class ReturnObjectFilesResponse
    {
        public IEnumerable<File> FilesObjs { get; set; }
    }

    public class FileObj
    {
        public byte[] File { get; set; }
    }
}
