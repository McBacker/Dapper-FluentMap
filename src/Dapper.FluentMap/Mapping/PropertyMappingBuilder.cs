using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    public class PropertyMappingBuilder : IPropertyMappingBuilder
    {
        public PropertyMappingBuilder(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            PropertyMapping = CreatePropertyMapping(propertyInfo);
        }

        public PropertyInfo PropertyInfo { get; }

        public IPropertyMapping PropertyMapping { get; }

        protected virtual IPropertyMapping CreatePropertyMapping(PropertyInfo propertyInfo) => new PropertyMapping(propertyInfo);

        public IPropertyMappingBuilder ToColumn(string columnName)
        {
            PropertyMapping.ColumnName = columnName;
            return this;
        }

        public IPropertyMapping Build() => PropertyMapping;
    }
}
