using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Dapper.FluentMap.Utils;

namespace Dapper.FluentMap.Mapping
{
    public class EntityMappingBuilder<TEntity> : IEntityMappingBuilder<TEntity>
    {
        private readonly List<IPropertyMappingBuilder> _propertyMappingBuilders = new List<IPropertyMappingBuilder>();

        public EntityMappingBuilder()
        {
            EntityMapping = CreateEntityMapping();
        }

        protected virtual IEntityMapping CreateEntityMapping() => new EntityMapping();

        protected virtual IPropertyMappingBuilder CreatePropertyMappingBuilder(PropertyInfo propertyInfo) => new PropertyMappingBuilder(propertyInfo);

        public IEntityMapping EntityMapping { get; }

        public IPropertyMappingBuilder Map(Expression<Func<TEntity, object>> mapping)
        {
            // Resolve property info from expression and guard against duplicate mappings.
            var propertyInfo = (PropertyInfo)ReflectionHelper.GetMemberInfo(mapping);
            if (_propertyMappingBuilders.Any(builder => builder.PropertyInfo == propertyInfo))
            {
                throw new Exception($"Duplicate mapping detected. Property '{propertyInfo.Name}' is already mapped.");
            }

            // Create a mapping builder from the property info and assign it to the entity mapping.
            var propertyMappingBuilder = CreatePropertyMappingBuilder(propertyInfo);
            _propertyMappingBuilders.Add(propertyMappingBuilder);
            return propertyMappingBuilder;
        }

        public void IsCaseSensitive(bool caseSensitive) => EntityMapping.IsCaseSensitive = caseSensitive;

        public IEntityMapping Build()
        {
            var propertyMaps = _propertyMappingBuilders.Select(b => b.Build()).ToList();
            EntityMapping.PropertyMappings = propertyMaps;
            return EntityMapping;
        }
    }
}
