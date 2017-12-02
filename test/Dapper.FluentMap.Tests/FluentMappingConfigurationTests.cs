using System.Linq;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Mapping;
using Dapper.FluentMap.TypeMaps;
using Xunit;

namespace Dapper.FluentMap.Tests
{
    public class FluentMappingConfigurationTests
    {
        [Fact]
        public void AddMap_AddsDapperTypeMap()
        {
            // Arrange
            var config = new FluentMappingConfiguration();
            var builder = new EntityMappingBuilder<TestEntity2>();
            builder.Map(p => p.Id).ToColumn("entity_id");

            // Act
            config.AddMap(builder);

            // Assert
            var mappings = config.EntityMappings;

            // Did it add a single entity mapping?
            Assert.Single(mappings);
            var mapping = mappings.Single();

            // Did it add a single property mapping?
            Assert.Single(mapping.Value.PropertyMappings);
            var propertyMapping = mapping.Value.PropertyMappings.Single();
            Assert.Equal("entity_id", propertyMapping.ColumnName);
            Assert.Equal(typeof(TestEntity2).GetProperty("Id"), propertyMapping.PropertyInfo);

            // Did it add our Dapper type map implementation?
            var typeMap = SqlMapper.GetTypeMap(typeof(TestEntity2));
            Assert.IsType<FluentMapTypeMap<TestEntity2>>(typeMap);

            // Does it correctly maps the mapped column?
            var idMap = typeMap.GetMember("entity_id");
            Assert.NotNull(idMap);
            Assert.Equal(typeof(TestEntity2).GetProperty("Id"), idMap.Property);
        }

        private class TestEntity2
        {
            public string Id { get; set; }
        }
    }
}
