using Dapper.FluentMap.Mapping;
using Dapper.FluentMap.TypeMaps;
using Xunit;

namespace Dapper.FluentMap.Tests
{
    public class FluentMapTypeMapTests
    {
        [Fact]
        public void FluentMapTypeMap_ReturnsCorrectMemberMap()
        {
            // Arrange
            var builder = new EntityMappingBuilder<TestEntity>();
            builder.Map(p => p.Id).ToColumn("id");
            builder.Map(p => p.Description).ToColumn("desc");
            var mapping = builder.Build();
            var dict = mapping.Compile();
            var typeMap = new FluentMapTypeMap<TestEntity>(dict);

            // Act
            var memberMap = typeMap.GetMember("desc");

            // Assert
            Assert.Equal("desc", memberMap.ColumnName);
            Assert.Equal(typeof(string), memberMap.MemberType);
            Assert.Equal(typeof(TestEntity).GetProperty("Description"), memberMap.Property);
        }
    }
}
