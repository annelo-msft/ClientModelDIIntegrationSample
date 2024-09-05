using Clients.ToyClient;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspireIntegrationToy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ToyClient _client;

        // 5. Code behind constructor takes client
        // TODO: why can we add ToyClient as a constructor parameter?
        public IndexModel(ILogger<IndexModel> logger, ToyClient client)
        {
            _client = client;
            _logger = logger;
        }

        public void OnGet()
        {
            // 6. Client call in request callback
            _client.CallService();
        }
    }
}
