using System.Collections.Generic;
using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Defines the mapping of an entity.
    /// </summary>
    public interface IEntityMapping
    {
        ICollection<IPropertyMapping> PropertyMappings { get; set; }

        bool IsCaseSensitive { get; set; }

        Dictionary<string, PropertyInfo> Compile();
    }
}
