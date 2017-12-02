using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Default <see cref="IPropertyMappingBuilder"/> implementation.
    /// </summary>
    public class PropertyMappingBuilder : IPropertyMappingBuilder
    {
        public PropertyMappingBuilder(PropertyInfo propertyInfo)
        {
            Property = propertyInfo;
            PropertyMapping = CreatePropertyMapping(propertyInfo);
        }

        public PropertyInfo Property { get; }

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
