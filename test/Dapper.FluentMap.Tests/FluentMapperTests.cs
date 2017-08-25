using System;
using Dapper.FluentMap.Configuration;
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
            var msg = "FluentMapper is not initialized. Use FluentMapper.Initialize() to configure your mappings.";
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
    }
}
