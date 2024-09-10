using Microsoft.Extensions.ClientModel;
using Clients.ToyClient;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Sample steps:
//
//       1. App Program: Register client with service collection: builder.AddClient
//       2. Extension: Get endpoint from configuration
//       3. Extension: Add options to service collection
//       4. Extension: Add client creation delegate: IServiceProvider => TClient
//       5. App Page: Code behind/PageModel constructor can take client
//       6. App Page: Call client from request callback
//
// Questions:
//   TODO: Is it better to take IServiceCollection than IBuilder?  How to do it?
//   TODO: Is this a good way to add options to be available at client creation time?  Is there a better way?
//   TODO: Is there a better way to get the settings from configuration?

builder.Services.AddRazorPages();

// Add HttpClient
builder.Services.AddHttpClient("MyClient");

// 1. Register the client with service collection
builder.AddToyClient();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
