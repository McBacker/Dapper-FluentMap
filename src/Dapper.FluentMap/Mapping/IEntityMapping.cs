using System.Collections.Generic;
using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Defines the mapping of an entity.
    /// </summary>
    public interface IEntityMapping
    {
        ICollection<IPropertyMapping> PropertyMappings { get; }

        bool IsCaseSensitive { get; }

        Dictionary<string, PropertyInfo> Compile();
    }
}
