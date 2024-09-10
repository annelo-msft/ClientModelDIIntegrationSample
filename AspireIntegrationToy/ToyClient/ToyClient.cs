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

    private readonly ClientPipeline _pipeline;

    public ToyClient(Uri endpoint, ClientPipelineOptions options)
    {
        _endpoint = endpoint;
        _logger = options.LoggerFactory.CreateLogger<ToyClient>();

        _pipeline = ClientPipeline.Create(options);
    }

    public void CallService(RequestOptions? options = default)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.Request.Uri = new Uri("https://www.microsoft.com");
        _pipeline.Send(message);

        PipelineResponse response = message.Response!;

        _logger.Log(LogLevel.Information, $"ToyClient: response status code is {response.Status}");

        LogMessage();
    }

    private void LogMessage()
    {
        _logger.Log(LogLevel.Information, $"ToyClient message: {_endpoint}");
    }
}
