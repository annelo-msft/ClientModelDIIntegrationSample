using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Http;

namespace HttpClientFactoryToy.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        HttpClient httpClient,
        ILogger<IndexModel> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        using HttpResponseMessage response = await _httpClient.GetAsync("https://www.microsoft.com");

        HttpStatusCode status = response.StatusCode;
    }
}
