using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Provider a builder to create <see cref="IPropertyMapping"/> instances.
    /// </summary>
    public interface IPropertyMappingBuilder
    {
        /// <summary>
        /// Gets a reference to the <see cref="IPropertyMapping"/> being built.
        /// </summary>
        IPropertyMapping PropertyMapping { get; }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> instance associated with this builder.
        /// </summary>
        PropertyInfo Property { get; }

        /// <summary>
        /// Specifies the column name for this property.
        /// </summary>
        /// <param name="columnName">The name of the column in the underlying data store.</param>
        /// <returns>This <see cref="IPropertyMappingBuilder"/> instance.</returns>
        IPropertyMappingBuilder ToColumn(string columnName);

        /// <summary>
        /// Builds the <see cref="IPropertyMapping"/> instance from this builder instance.
        /// </summary>
        /// <returns>A <see cref="IPropertyMapping"/> instance.</returns>
        IPropertyMapping Build();
    }
}
