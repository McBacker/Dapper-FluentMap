using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    public interface IDommelPropertyMapping : IPropertyMapping
    {
        bool IsKey { get; set; }
    }
}
