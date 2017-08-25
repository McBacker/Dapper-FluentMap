using System;
using System.Linq.Expressions;
using Dapper.FluentMap.Configuration;

namespace Dapper.FluentMap.Mapping
{
    public interface IEntityMappingBuilder<TEntity> : IFluentInterface
    {
        IPropertyMappingBuilder Map(Expression<Func<TEntity, object>> mapping);

        void IsCaseSensitive(bool caseSensitive);

        IEntityMapping Build();
    }
}
