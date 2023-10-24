using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPlugin.DynamicHandlers
{
    public class DynamicTestHandler : BaseInvocable, IDataSourceHandler
    {
        public DynamicTestHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public Dictionary<string, string> GetData(DataSourceContext context)
        {
            Dictionary<string, string> dictionary = new() { { "test 1", "1" }, { "test 2", "2" }, { "test 3", "3" } };
            return dictionary.Where(x => x.Key.Contains(context.SearchString)).ToDictionary(k => k.Key, v => v.Value);
        }
    }
}
