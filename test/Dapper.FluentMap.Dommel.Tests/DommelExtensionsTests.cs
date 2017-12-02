using System.Linq;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Dommel.Mapping;
using Xunit;

namespace Dapper.FluentMap.Dommel.Tests
{
    public class DommelExtensionsTests
    {
        [Fact]
        public void InlineDommelConfiguration_MapsDommelSpecificConfiguration()
        {
            // Arrange
            var config = new FluentMappingConfiguration();

            // Act
            config.DommelEntity<TestEntity>(builder =>
            {
                builder.ToTable("test");
                builder.Map(p => p.Id)
                    .ToColumn("id")
                    .IsKey();
            });

            // Assert
            AssertMapping(config);
        }

        [Fact]
        public void DommelEntityMappingBuilder_MapsDommelSpecificConfiguration()
        {
            // Arrange
            var config = new FluentMappingConfiguration();

            // Act
            config.AddMap(new TestEntityMap());

            // Assert
            AssertMapping(config);
        }

        private void AssertMapping(FluentMappingConfiguration config)
        {
            Assert.Single(config.EntityMappings);
            var entityMapping = config.EntityMappings.Values.First();
            Assert.IsType<DommelEntityMapping>(entityMapping);
            var dommelEntityMapping = (DommelEntityMapping)entityMapping;
            Assert.Equal("test", dommelEntityMapping.TableName);

            Assert.Single(dommelEntityMapping.PropertyMappings);
            var propertyMapping = dommelEntityMapping.PropertyMappings.First();
            Assert.IsType<DommelPropertyMapping>(propertyMapping);
            var dommelPropertyMapping = (DommelPropertyMapping)propertyMapping;
            Assert.Equal("id", dommelPropertyMapping.ColumnName);
            Assert.True(dommelPropertyMapping.IsKey);
            Assert.Equal(typeof(TestEntity).GetProperty("Id"), dommelPropertyMapping.PropertyInfo);
        }
    }

    public class TestEntityMap : DommelEntityMappingBuilder<TestEntity>
    {
        public TestEntityMap()
        {
            ToTable("test");
            Map(p => p.Id)
                .ToColumn("id")
                .IsKey();
        }
    }

    public class TestEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
