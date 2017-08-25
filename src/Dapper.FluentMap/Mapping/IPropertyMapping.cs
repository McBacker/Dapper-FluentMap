using System.Reflection;

namespace Dapper.FluentMap.Mapping
{
    public interface IPropertyMapping
    {
        PropertyInfo PropertyInfo { get; }

        string ColumnName { get; }
    }
}
