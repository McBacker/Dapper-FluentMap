using System;
using System.Linq.Expressions;

namespace Dapper.FluentMap.Mapping
{
    public interface IEntityMappingBuilder<TEntity> : IFluentInterface
    {
        IEntityMapping EntityMapping { get; }

        IPropertyMappingBuilder Map(Expression<Func<TEntity, object>> mapping);

        void IsCaseSensitive(bool caseSensitive);

        IEntityMapping Build();
    }
}
