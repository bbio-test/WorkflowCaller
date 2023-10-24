using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPlugin.DynamicHandlers;

namespace TestPlugin.Dtos.DynamicInputActions
{
    public class DynamicRequiredRequest
    {
        [DataSource(typeof(DynamicTestHandler))]
        public string DynamicInput { get; set; }
    }
}
