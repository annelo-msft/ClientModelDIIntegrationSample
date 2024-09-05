using Microsoft.Extensions.Logging;
using System.ClientModel.Primitives;

namespace Clients.ToyClient;

public class ToyClient
{
    private readonly Uri _endpoint;
    private readonly ILogger _logger;

    public ToyClient(Uri endpoint, ClientPipelineOptions options)
    {
        _endpoint = endpoint;
        _logger = options.LoggerFactory.CreateLogger<ToyClient>();
    }

    public void CallService(RequestOptions? options = default)
    {
        LogMessage();
    }

    private void LogMessage()
    {
        _logger.Log(LogLevel.Information, $"ToyClient message: {_endpoint}");
    }
}
