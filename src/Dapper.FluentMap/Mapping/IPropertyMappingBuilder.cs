using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    public interface IPropertyMappingBuilder
    {
        PropertyInfo PropertyInfo { get; }

        IPropertyMapping PropertyMapping { get; }

        IPropertyMappingBuilder ToColumn(string columnName);

        IPropertyMapping Build();
    }
}
