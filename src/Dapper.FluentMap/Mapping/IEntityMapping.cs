using System.Collections.Generic;
using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Defines the mapping of an entity.
    /// </summary>
    public interface IEntityMapping
    {
        /// <summary>
        /// Gets a collection of <see cref="IPropertyMapping"/> instances.
        /// </summary>
        ICollection<IPropertyMapping> PropertyMappings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating this entity mapping is case-sensitive.
        /// </summary>
        bool IsCaseSensitive { get; set; }

        /// <summary>
        /// Compiles the current <see cref="IEntityMapping"/> instance to a mapping 
        /// between column names and <see cref="PropertyInfo"/> instances.
        /// </summary>
        /// <returns>A <see cref="Dictionary{TKey, TValue}"/> which represents the mapping.</returns>
        Dictionary<string, PropertyInfo> Compile();
    }
}
