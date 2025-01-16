using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Sagogenerator.Components;
using Sagogenerator.Components.Services;
using Sagogenerator.Data;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//AppDbContext databasContext = new AppDbContext(configuration);
//databasContext.Database.EnsureCreated();
//databasContext.SeedDB();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IStoryService, StoryService>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<OpenAIService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/logga-in";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
