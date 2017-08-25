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
        private readonly EntityMapping _entityMapping = new EntityMapping();
        private readonly List<IPropertyMappingBuilder> _propertyMappingBuilders = new List<IPropertyMappingBuilder>();

        public IPropertyMappingBuilder Map(Expression<Func<TEntity, object>> mapping)
        {
            // Resolve property info from expression and guard against duplicate mappings.
            var pi = (PropertyInfo)ReflectionHelper.GetMemberInfo(mapping);
            if (_propertyMappingBuilders.Any(builder => builder.PropertyInfo == pi))
            {
                throw new Exception($"Duplicate mapping detected. Property '{pi.Name}' is already mapped.");
            }

            // Create a mapping builder from the property info and assign it to the entity mapping.
            var propertyMappingBuilder = new PropertyMappingBuilder(pi);
            _propertyMappingBuilders.Add(propertyMappingBuilder);
            return propertyMappingBuilder;
        }

        public void IsCaseSensitive(bool caseSensitive) => _entityMapping.IsCaseSensitive = caseSensitive;

        public IEntityMapping Build()
        {
            var propertyMaps = _propertyMappingBuilders.Select(b => b.Build()).ToList();
            _entityMapping.PropertyMappings = propertyMaps;
            return _entityMapping;
        }
    }
}
