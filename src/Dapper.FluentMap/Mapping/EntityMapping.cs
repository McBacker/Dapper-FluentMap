using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    public class EntityMapping : IEntityMapping
    {
        public ICollection<IPropertyMapping> PropertyMappings { get; set; } = new List<IPropertyMapping>();

        public bool IsCaseSensitive { get; set; }

        public Dictionary<string, PropertyInfo> Compile()
        {
            return PropertyMappings.ToDictionary(m => m.ColumnName, m => m.PropertyInfo, IsCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
        }
    }
}
