using Journey.Business.Model.Domain;
using Journey.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IJourneyService, JourneyService>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<ISessionService, SessionService>();

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

builder.Services.Configure<AppSettings>(configuration);//(builder.Configuration.GetSection("AppSettings"));

//(Configuration.GetSection(nameof(AppSettings)));

builder.Services.AddHttpClient(); // 

var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dashboard/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
