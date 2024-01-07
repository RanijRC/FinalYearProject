using CRMS.Blazor.Components;
using CRMS.Application.Common.Interface;
using CRMS.Infrastructure.DI;
using CRMS.Infrastructure.Services;
using CRMS.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.AddScoped<IAuthentication, AuthenticationService>();
builder.Services.AddHttpClient();
builder.Services.AddTransient<ApiService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting(); //for identity
app.UseAuthentication(); //for identity
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
