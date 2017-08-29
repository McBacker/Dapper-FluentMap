using System.Reflection;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    public class DommelPropertyMapping : PropertyMapping, IDommelPropertyMapping
    {
        public DommelPropertyMapping(PropertyInfo propertyInfo) : base(propertyInfo)
        {
        }

        public bool IsKey { get; set; }
    }
}
