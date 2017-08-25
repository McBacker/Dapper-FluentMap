using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    public class PropertyMappingBuilder : IPropertyMappingBuilder
    {
        private readonly PropertyMapping _propertyMapping;

        protected virtual IPropertyMapping PropertyMapping => _propertyMapping;

        public PropertyMappingBuilder(PropertyInfo propertyInfo)
        {
            _propertyMapping = new PropertyMapping(propertyInfo);
            PropertyInfo = propertyInfo;
        }

        public PropertyInfo PropertyInfo { get; }

        public IPropertyMappingBuilder ToColumn(string columnName)
        {
            _propertyMapping.ColumnName = columnName;
            return this;
        }

        public IPropertyMapping Build()
        {
            return _propertyMapping;
        }
    }
}
