using Blazored.LocalStorage;
using CRMS.Application.Helpers;
using CRMS.Application.Services.Contracts;
using CRMS.Application.Services.Implementation;
using CRMS.Blazor;
using CRMS.Blazor.ApplicationState;
using CRMS.Domain.Entities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzIyNTM0NkAzMjM1MmUzMDJlMzBpTFI2MVRrbitsYVA1b0FZZlF6WW4yQmZlbHdna3Z4R2FKa2JsRVhMYU5zPQ==");

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7249/");
}).AddHttpMessageHandler<CustomHttpHandler>(); ;
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7249/") });
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

//General Department / Department/ Branch
builder.Services.AddScoped<IGenericServiceInterface<GeneralDepartment>, GenericServiceImplementation<GeneralDepartment>>();
builder.Services.AddScoped<IGenericServiceInterface<Faculty>, GenericServiceImplementation<Faculty>>();
builder.Services.AddScoped<IGenericServiceInterface<Branch>, GenericServiceImplementation<Branch>>();

//Country / City / Town
builder.Services.AddScoped<IGenericServiceInterface<Country>, GenericServiceImplementation<Country>>();
builder.Services.AddScoped<IGenericServiceInterface<City>, GenericServiceImplementation<City>>();
builder.Services.AddScoped<IGenericServiceInterface<Town>, GenericServiceImplementation<Town>>();

//Complaint
builder.Services.AddScoped<IGenericServiceInterface<Complaint>, GenericServiceImplementation<Complaint>>();

//Feedback / Data Pending /Complaint Complete
builder.Services.AddScoped<IGenericServiceInterface<Feedback>, GenericServiceImplementation<Feedback>>();
builder.Services.AddScoped<IGenericServiceInterface<DataPending>, GenericServiceImplementation<DataPending>>();
builder.Services.AddScoped<IGenericServiceInterface<DataPendingType>, GenericServiceImplementation<DataPendingType>>();
builder.Services.AddScoped<IGenericServiceInterface<ComplaintComplete>, GenericServiceImplementation<ComplaintComplete>>();
builder.Services.AddScoped<IGenericServiceInterface<ComplaintCompleteType>, GenericServiceImplementation<ComplaintCompleteType>>();


builder.Services.AddScoped<AllState>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();

await builder.Build().RunAsync();
