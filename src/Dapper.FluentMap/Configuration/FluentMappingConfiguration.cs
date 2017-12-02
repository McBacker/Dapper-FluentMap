using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Dapper.FluentMap.Mapping;
using Dapper.FluentMap.TypeMaps;

namespace Dapper.FluentMap.Configuration
{
    /// <summary>
    /// <see cref="IMappingConfiguration"/> implementation for fluent mapping configuration.
    /// </summary>
    public class FluentMappingConfiguration : IMappingConfiguration
    {
        private ConcurrentDictionary<Type, IEntityMapping> _entityMappings = new ConcurrentDictionary<Type, IEntityMapping>();

        public IDictionary<Type, IEntityMapping> EntityMappings => _entityMappings;

        public void AddMap<TEntity>(IEntityMappingBuilder<TEntity> entityMappingBuilder)
        {
            var entityMapping = entityMappingBuilder.Build();
            if (_entityMappings.TryAdd(typeof(TEntity), entityMapping))
            {
                // Compile the defined mapping into a column <-> property lookup dictionary.
                var mapping = entityMapping.Compile();
                SqlMapper.SetTypeMap(typeof(TEntity), new FluentMapTypeMap<TEntity>(mapping));
            }
        }

        public void Entity<TEntity>(Action<IEntityMappingBuilder<TEntity>> action)
        {
            var builder = new EntityMappingBuilder<TEntity>();
            action(builder);
            AddMap(builder);
        }
    }
}
