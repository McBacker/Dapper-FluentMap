using System;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Dommel.Mapping;

namespace Dapper.FluentMap.Dommel
{
    public static class DommelFluentMapExtensions
    {
        public static void DommelEntity<T>(this IMappingConfiguration config, Action<IDommelEntityMappingBuilder<T>> action)
        {
            var builder = new DommelEntityMappingBuilder<T>();
            action(builder);
            var mapping = builder.Build();
            config.AddMap(builder);
        }
    }
}
