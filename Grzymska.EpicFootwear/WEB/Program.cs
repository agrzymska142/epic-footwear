using Grzymska.EpicFootwear.BLC;
using Grzymska.EpicFootwear.WEB.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<DataProvider>(provider =>
{
    IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
    string daoName = configuration["DAO_Name"];

    string currentDirectory = Directory.GetCurrentDirectory() + @"/bin/Debug/net8.0/";

    string daoPath = Path.Combine(currentDirectory, daoName);

    return new DataProvider(daoPath);
});

builder.Services.AddControllers();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.UseAntiforgery();

app.UseEndpoints(endpoints =>
    endpoints.MapControllers());


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
