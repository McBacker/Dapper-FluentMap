using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    public interface IDommelEntityMapping : IEntityMapping
    {
        string TableName { get; set; }
    }

    public class DommelEntityMapping : EntityMapping, IDommelEntityMapping
    {
        public string TableName { get; set; }
    }
}
