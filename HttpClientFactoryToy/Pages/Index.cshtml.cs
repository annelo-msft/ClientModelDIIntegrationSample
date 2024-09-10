using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Http;

namespace HttpClientFactoryToy.Pages;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        IHttpClientFactory httpClientFactory,
        ILogger<IndexModel> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        using HttpClient client = _httpClientFactory.CreateClient();

        using HttpResponseMessage response = await client.GetAsync("https://www.microsoft.com");

        HttpStatusCode status = response.StatusCode;
    }
}
