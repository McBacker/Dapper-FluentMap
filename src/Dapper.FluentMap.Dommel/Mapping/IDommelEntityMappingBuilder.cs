using System;
using System.Linq.Expressions;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    public interface IDommelEntityMappingBuilder<TEntity> : IEntityMappingBuilder<TEntity>, IFluentInterface
    {
        new IDommelEntityMapping EntityMapping { get; }

        new IDommelPropertyMappingBuilder Map(Expression<Func<TEntity, object>> mapping);

        void ToTable(string tableName);
    }
}
