using System;
using Dapper.FluentMap.Configuration;

namespace Dapper.FluentMap
{
    /// <summary>
    /// Main entry point for Dapper.FluentMap configuration.
    /// </summary>
    public static class FluentMapper
    {
        private static IMappingConfiguration _configuration;

        /// <summary>
        /// Gets or sets a reference to the currently configured <see cref="IMappingConfiguration"/> instance.
        /// </summary>
        public static IMappingConfiguration Configuration
        {
            get => _configuration ?? throw new InvalidOperationException($"FluentMapper is not initialized. Use {nameof(FluentMapper.Initialize)} to configure your mappings.");
            set => _configuration = value;
        }

        /// <summary>
        /// Initializes Dapper.FluentMap with the specified configuration.
        /// This method should be called when the application starts or when the first mapping is required.
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
}
