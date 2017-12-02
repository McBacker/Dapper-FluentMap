using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    /// <summary>
    /// Default <see cref="IPropertyMapping"/> implementation.
    /// </summary>
    public class PropertyMapping : IPropertyMapping
    {
        public PropertyMapping(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
        }

        public PropertyInfo PropertyInfo { get; }

        public string ColumnName { get; set; }
    }
}
