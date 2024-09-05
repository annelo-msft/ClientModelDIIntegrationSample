using Microsoft.Extensions.Logging;

// Reference SCM version in
// https://github.com/annelo-msft/azure-sdk-for-net/tree/aspire-aoai-demo
// to get LoggerFactory on options for sample to run.
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
