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
            var builder = new EntityMappingBuilder<TestEntity>();
            builder.Map(p => p.Id).ToColumn("id");

            // Act
            config.AddMap(builder);

            // Assert
            var mappings = config.EntityMappings;

            // Did it add a single entity mapping?
            Assert.Single(mappings);
            var mapping = mappings.Single();

            // Did it add our Dapper type map implementation?
            var typeMap = SqlMapper.GetTypeMap(typeof(TestEntity));
            Assert.IsType<FluentMapTypeMap<TestEntity>>(typeMap);

            // Does it correctly maps the mapped column?
            var idMap = typeMap.GetMember("id");
            Assert.Equal(typeof(TestEntity).GetProperty("Id"), idMap.Property);
        }
    }
}
