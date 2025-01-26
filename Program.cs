using ConsumeCourseApi.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IApiService, ApiService>();
string uristring = builder.Configuration["ApiBaseUrl"];
builder.Services.AddHttpClient();

/*builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(uristring);
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});*/

// Add HttpClient to DI
builder.Services.AddHttpClient("ApiClient", client =>
{
    // Set the base address from configuration
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json"); // Optional
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

app.Run();
