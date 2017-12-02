using System.Collections.Generic;
using System.Reflection;

namespace Dapper.FluentMap.TypeMaps
{
    /// <summary>
    /// Represents a Dapper type mapping strategy using the configured entity mappings.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class FluentMapTypeMap<TEntity> : MultiTypeMap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentMapTypeMap{TEntity}"/> class using the specified <paramref name="mapping"/>.
        /// </summary>
        /// <param name="mapping">A dictionary which represents the mapping of the current entity.</param>
        public FluentMapTypeMap(Dictionary<string, PropertyInfo> mapping)
            : base(new CustomPropertyTypeMap(typeof(TEntity), (t, c) => GetPropertyInfo(mapping, c)), new DefaultTypeMap(typeof(TEntity)))
        {
        }

        private static PropertyInfo GetPropertyInfo(Dictionary<string, PropertyInfo> mapping, string columnName)
        {
            return mapping.TryGetValue(columnName, out var propertyInfo) ? propertyInfo : null;
        }
    }
}
