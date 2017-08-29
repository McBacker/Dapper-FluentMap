using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    public interface IDommelPropertyMappingBuilder : IPropertyMappingBuilder
    {
        new IDommelPropertyMapping PropertyMapping { get; }

        new IDommelPropertyMappingBuilder ToColumn(string columnName);

        IDommelPropertyMappingBuilder IsKey();
    }
}
