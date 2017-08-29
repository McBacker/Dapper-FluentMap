using System;
using System.Linq.Expressions;
using System.Reflection;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap.Dommel.Mapping
{
    public class DommelEntityMappingBuilder<TEntity> : EntityMappingBuilder<TEntity>, IDommelEntityMappingBuilder<TEntity>
    {
        protected override IEntityMapping CreateEntityMapping() => new DommelEntityMapping();

        public new IDommelEntityMapping EntityMapping => (DommelEntityMapping)base.EntityMapping;

        public new IDommelPropertyMappingBuilder Map(Expression<Func<TEntity, object>> mapping) => (IDommelPropertyMappingBuilder)base.Map(mapping);

        protected override IPropertyMappingBuilder CreatePropertyMappingBuilder(PropertyInfo propertyInfo) => new DommelPropertyMappingBuilder(propertyInfo);

        public void ToTable(string tableName) => EntityMapping.TableName = tableName;
    }
}
