using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    public interface IPropertyMappingBuilder
    {
        PropertyInfo PropertyInfo { get; }

        IPropertyMappingBuilder ToColumn(string columnName);

        IPropertyMapping Build();
    }
}
