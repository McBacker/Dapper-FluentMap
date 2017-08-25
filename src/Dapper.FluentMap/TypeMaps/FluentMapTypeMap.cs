using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Dapper.FluentMap.TypeMaps
{
    public class FluentMapTypeMap<TEntity> : MultiTypeMap
    {
        private static readonly ConcurrentDictionary<string, PropertyInfo> _cache = new ConcurrentDictionary<string, PropertyInfo>();

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
