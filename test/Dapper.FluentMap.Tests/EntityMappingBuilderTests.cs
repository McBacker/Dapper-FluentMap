using System;
using System.Linq;
using Dapper.FluentMap.Mapping;
using Xunit;

namespace Dapper.FluentMap.Tests
{
    public class EntityMappingBuilderTests
    {
        [Fact]
        public void Map_WithDuplicateMapping_ThrowsException()
        {
            // Arrange
            var builder = new EntityMappingBuilder<TestEntity>();
            builder.Map(p => p.Id).ToColumn("id");

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => builder.Map(p => p.Id).ToColumn("id"));
            Assert.Equal("Duplicate mapping detected. Property 'Id' is already mapped.", ex.Message);
        }

        [Fact]
        public void Maps_SingleColumnName()
        {
            // Arrange
            var builder = new EntityMappingBuilder<TestEntity>();
            builder.Map(p => p.Id).ToColumn("id");

            // Act
            var mapping = builder.Build();


            // Assert
            Assert.Single(mapping.PropertyMappings);
            var propertyMap = mapping.PropertyMappings.Single();
            Assert.Equal("id", propertyMap.ColumnName);
        }

        [Fact]
        public void Maps_MultipleColumnNames()
        {
            // Arrange
            var builder = new EntityMappingBuilder<TestEntity>();
            builder.Map(p => p.Id).ToColumn("id");
            builder.Map(p => p.Description).ToColumn("desc");

            // Act
            var mapping = builder.Build();

            // Assert
            Assert.Equal(2, mapping.PropertyMappings.Count);
            var first = mapping.PropertyMappings.First();
            Assert.Equal("id", first.ColumnName);

            var second = mapping.PropertyMappings.Skip(1).First();
            Assert.Equal("desc", second.ColumnName);
        }

        [Fact]
        public void IsCaseSensitive_SpecifiesCaseSensitivity()
        {
            // Arrange
            var builder = new EntityMappingBuilder<TestEntity>();
            builder.IsCaseSensitive(false);

            // Act
            var mapping = builder.Build();

            // Assert
            Assert.False(mapping.IsCaseSensitive);
            Assert.Empty(mapping.PropertyMappings);
        }

        [Fact]
        public void Compile_CompilesDictionary()
        {
            // Arrange
            var builder = new EntityMappingBuilder<TestEntity>();
            builder.Map(p => p.Id).ToColumn("id");
            builder.Map(p => p.Description).ToColumn("desc");
            var mapping = builder.Build();

            // Act
            var dict = mapping.Compile();

            // Assert
            Assert.Equal(2, dict.Count);
            var first = dict.First();
            Assert.Equal("id", first.Key);
            Assert.Equal(typeof(TestEntity).GetProperty("Id"), first.Value);

            var second = dict.Skip(1).First();
            Assert.Equal("desc", second.Key);
            Assert.Equal(typeof(TestEntity).GetProperty("Description"), second.Value);
        }
    }
}
