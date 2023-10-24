using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Authentication.OAuth2;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace TestPlugin
{
    internal class TestPluginApplication : IApplication
    {
        private readonly Dictionary<Type, object> _typesInstances;

        public TestPluginApplication()
        {
        }
        
        public string Name
        {
            get => "TestArraysPlugin";
            set { }
        }

        public T GetInstance<T>()
        {
            if (!_typesInstances.TryGetValue(typeof(T), out var value))
            {
                throw new InvalidOperationException($"Instance of type '{typeof(T)}' not found");
            }
            return (T)value;
        }

        
    }
}
