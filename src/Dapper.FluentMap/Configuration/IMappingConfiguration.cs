using System;
using System.Collections.Generic;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Configuration
{
    /// <summary>
    /// Contains the configuration for Dapper.FluentMap.
    /// </summary>
    public interface IMappingConfiguration : IFluentInterface
    {
        /// <summary>
        /// Gets a collection of entity mappings.
        /// </summary>
        IDictionary<Type, IEntityMapping> EntityMappings { get; }

        /// <summary>
        /// Configures the mapping for <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="action">A delegate which configures the mapping for <typeparamref name="TEntity"/>.</param>
        void Entity<TEntity>(Action<IEntityMappingBuilder<TEntity>> action);

        /// <summary>
        /// Adds the specified <see cref="IEntityMappingBuilder{TEntity}"/> instance to this configuration instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entityMappingBuilder">
        /// An instance of <see cref="IEntityMappingBuilder{TEntity}"/> which represents the mapping for <typeparamref name="TEntity"/>.
        /// </param>
        void AddMap<TEntity>(IEntityMappingBuilder<TEntity> entityMappingBuilder);
    }
}
