using System;
using System.Collections.Generic;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Configuration
{
    public interface IMappingConfiguration : IFluentInterface
    {
        IDictionary<Type, IEntityMapping> EntityMappings { get; }

        void Entity<TEntity>(Action<IEntityMappingBuilder<TEntity>> action);

        void AddMap<TEntity>(IEntityMappingBuilder<TEntity> entityMappingBuilder);
    }
}
