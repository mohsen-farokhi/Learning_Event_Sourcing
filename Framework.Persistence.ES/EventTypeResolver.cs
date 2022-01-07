using Framework.Domain;
using System.Diagnostics;
using System.Reflection;

namespace Framework.Persistence.ES
{
    public interface IEventTypeResolver
    {
        void AddTypeFromAssembly(Assembly assembly);
        Type GetType(string typeName);
    }

    public class EventTypeResolver : IEventTypeResolver
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();
        public void AddTypeFromAssembly(Assembly assembly)
        {
            var events = 
                assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(DomainEvent)))
                .ToList();

            //Debug.Assert(events.GroupBy(c => c.Name).Count() == 1);

            events.ForEach(type =>
            {
                _types.Add(type.Name, type);
            });
        }

        public Type GetType(string typeName)
        {
            if (_types.ContainsKey(typeName))
            {
                return _types[typeName];
            }

            return null;
        }
    }
}
