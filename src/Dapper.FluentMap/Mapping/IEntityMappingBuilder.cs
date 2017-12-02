using System;
using System.Linq.Expressions;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Provider a builder to create <see cref="IEntityMapping"/> instances for <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEntityMappingBuilder<TEntity> : IFluentInterface
    {
        /// <summary>
        /// Gets a reference to the <see cref="IEntityMapping"/> being built.
        /// </summary>
        IEntityMapping EntityMapping { get; }

        /// <summary>
        /// Returns a <see cref="IPropertyMappingBuilder"/> instance to configure 
        /// the mapping for the specified property of <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="mapping">An epxression which represents the property to be mapped.</param>
        /// <returns>A <see cref="IPropertyMappingBuilder"/> instance.</returns>
        IPropertyMappingBuilder Map(Expression<Func<TEntity, object>> mapping);

        /// <summary>
        /// Specifies whether the <see cref="IEntityMapping"/> is case-sensitive.
        /// </summary>
        void IsCaseSensitive(bool caseSensitive);

        /// <summary>
        /// Builds the <see cref="IEntityMapping"/> instance from this builder instance.
        /// </summary>
        /// <returns>A <see cref="IEntityMapping"/> instance.</returns>
        IEntityMapping Build();
    }
}
