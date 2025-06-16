using ClearKilovat.Components;
using ClearKilovat.DB;
using ClearKilovat.Interfaces;
using ClearKilovat.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Radzen;


var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreDBContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddHttpClient("BatchPredictClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
    client.Timeout = TimeSpan.FromSeconds(200);
});
builder.Services.AddSignalR(o =>
{
    o.MaximumReceiveMessageSize = 102400000; 
});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 102400000; 
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 102400000;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 102400000;
});
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRadzenComponents();
builder.Services.AddHttpClient<ICompanySearchService, CompanySearchService>();

builder.Services.AddScoped<IDbService, DbService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
