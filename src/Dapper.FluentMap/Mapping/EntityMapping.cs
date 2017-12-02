using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Default <see cref="IEntityMapping"/> implementation.
    /// </summary>
    public class EntityMapping : IEntityMapping
    {
        public ICollection<IPropertyMapping> PropertyMappings { get; set; } = new List<IPropertyMapping>();

        public bool IsCaseSensitive { get; set; } = true;

        public Dictionary<string, PropertyInfo> Compile()
            => PropertyMappings.ToDictionary(m => m.ColumnName, m => m.PropertyInfo, IsCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
    }
}
