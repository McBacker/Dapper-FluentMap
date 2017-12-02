using System;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Mapping;
using Xunit;

namespace Dapper.FluentMap.Tests
{
    public class FluentMapperTests
    {
        public FluentMapperTests()
        {
            // Clear any existing configuration first.
            FluentMapper.Configuration = null;
        }

        [Fact]
        public void GetConfiguration_WithoutInitialize_ThrowsException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => { var x = FluentMapper.Configuration; });
            var msg = $"FluentMapper is not initialized. Use {nameof(FluentMapper.Initialize)} to configure your mappings.";
            Assert.Equal(msg, ex.Message);
        }

        [Fact]
        public void Initialize_WithNullConfiguration_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>("configure", () => FluentMapper.Initialize(null));
        }

        [Fact]
        public void Initialize_WithoutConfiguration_ResultsInEmptyMappings()
        {
            FluentMapper.Initialize(config => { });
            Assert.IsType<FluentMappingConfiguration>(FluentMapper.Configuration);
            Assert.Empty(FluentMapper.Configuration.EntityMappings);
        }

        [Fact]
        public void Initialize_WithConfiguration_ConfiguresCorrectly()
        {
            FluentMapper.Initialize(c =>
            {
                c.Entity<TestEntity>(builder =>
                {
                    builder.Map(e => e.Id).ToColumn("autID");
                    builder.Map(e => e.Description).ToColumn("strDescription");
                });

                c.Entity<TestEntity2>(builder =>
                {
                    builder.IsCaseSensitive(false);
                    builder.Map(e => e.EntityId).ToColumn("Id");
                    builder.Map(e => e.Amount).ToColumn("EntityAmount");
                });

                c.AddMap(new TestEntity3Map());
            });

            var config = FluentMapper.Configuration;
            Assert.Equal(3, config.EntityMappings.Count);

            var first = config.EntityMappings[typeof(TestEntity)];
            Assert.IsType<EntityMapping>(first);
            Assert.True(first.IsCaseSensitive);
            Assert.Equal(2, first.PropertyMappings.Count);


            var second = config.EntityMappings[typeof(TestEntity2)];
            Assert.IsType<EntityMapping>(second);
            Assert.False(second.IsCaseSensitive);
            Assert.Equal(2, second.PropertyMappings.Count);


            var third = config.EntityMappings[typeof(TestEntity3)];
            Assert.IsType<EntityMapping>(third);
            Assert.True(third.IsCaseSensitive);
            Assert.Equal(2, third.PropertyMappings.Count);
        }
    }

    public class TestEntity2
    {
        public Guid EntityId { get; set; }

        public decimal? Amount { get; set; }
    }

    public class TestEntity3
    {
        public int EntityId { get; set; }

        public string Description { get; set; }
    }

    public class TestEntity3Map : EntityMappingBuilder<TestEntity3>
    {
        public TestEntity3Map()
        {
            Map(e => e.EntityId).ToColumn("entity_id");
            Map(e => e.Description).ToColumn("description");
        }
    }
}
