using System;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Mapping;

namespace Dapper.FluentMap
{
    /// <summary>
    /// Main entry point for Dapper.FluentMap configuration.
    /// </summary>
    public static class FluentMapper
    {
        private static IMappingConfiguration _configuration;

        public static IMappingConfiguration Configuration
        {
            get => _configuration ?? throw new InvalidOperationException("FluentMapper is not initialized. Use FluentMapper.Initialize() to configure your mappings.");
            set => _configuration = value;
        }

        /// <summary>
        /// Initializes Dapper.FluentMap with the specified configuration.
        /// This is method should be called when the application starts or when the first mapping is needed.
        /// </summary>
        /// <param name="configure">A callback containing the configuration of Dapper.FluentMap.</param>
        public static void Initialize(Action<IMappingConfiguration> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            Configuration = new FluentMappingConfiguration();
            configure(Configuration);
        }
    }

    public class Startup
    {
        public void Start()
        {
            FluentMapper.Initialize(config =>
            {
                config.Entity<TestEntity>(builder =>
                {
                    builder.IsCaseSensitive(false);
                    builder.Map(e => e.Id).ToColumn("autID");
                    builder.Map(e => e.Name).ToColumn("strName");
                });

                config.Entity<TestEntity2>(builder =>
                {
                    builder.Map(e => e.EntityId).ToColumn("Id");
                    builder.Map(e => e.Amount).ToColumn("EntityAmount");
                });

                config.AddMap(new TestEntity3Map());
            });
        }
    }
    public class TestEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
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
