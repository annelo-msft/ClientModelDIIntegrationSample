using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.ClientModel.Primitives;

namespace Microsoft.Extensions.ClientModel;

public static class ClientModelExtensions
{
    // TODO: Is it better to add the extension for a builder or a service collection?
    public static IServiceCollection AddClient<TClient>(
        this IHostApplicationBuilder builder,
        Func<Uri, ClientPipelineOptions, TClient> createClient)
            where TClient : class
    {
        // 2. Get endpoint from configuration
        IConfigurationSection configSection = builder.Configuration.GetSection("Client");

        string? endpoint = configSection["Endpoint"] ?? throw new InvalidOperationException("Client settings must provide endpoint.");
        Uri uri = new Uri(endpoint);

        // 3. Add options to service collection to later create the client
        // TODO: Would something like an AddOptions call be preferred?
        builder.Services.AddSingleton<ClientPipelineOptions>();

        // 4. Add client factory method that can access registered services
        builder.Services.AddSingleton<TClient>(provider =>
        {
            // TODO: should options be accessed differently from a service?
            ClientPipelineOptions options = provider.GetRequiredService<ClientPipelineOptions>();

            ILoggerFactory loggerFactory = provider.GetRequiredService<ILoggerFactory>();
            options.LoggerFactory = loggerFactory;

            return createClient(uri, options);
        });

        // TODO: What's best to return here?
        return builder.Services;
    }
}
