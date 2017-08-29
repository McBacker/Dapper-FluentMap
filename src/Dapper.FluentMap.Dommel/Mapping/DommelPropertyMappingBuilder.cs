using System.Reflection;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    public class DommelPropertyMappingBuilder : PropertyMappingBuilder, IDommelPropertyMappingBuilder
    {
        public DommelPropertyMappingBuilder(PropertyInfo propertyInfo) : base(propertyInfo)
        {
        }

        public new IDommelPropertyMapping PropertyMapping => base.PropertyMapping as IDommelPropertyMapping;

        public new IDommelPropertyMappingBuilder ToColumn(string columnName) => (IDommelPropertyMappingBuilder)base.ToColumn(columnName);

        protected override IPropertyMapping CreatePropertyMapping(PropertyInfo propertyInfo) => new DommelPropertyMapping(propertyInfo);

        public IDommelPropertyMappingBuilder IsKey()
        {
            PropertyMapping.IsKey = true;
            return this;
        }
    }
}
