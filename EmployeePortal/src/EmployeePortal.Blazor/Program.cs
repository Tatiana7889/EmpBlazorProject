using EmployeePortal.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAntiforgery();

// Add HttpClient so Blazor pages can call APIs
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("EmployeePortalApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5284"); // your API port
});

var app = builder.Build();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();




