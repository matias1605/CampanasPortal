using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var cultura = new CultureInfo("es-PE");
CultureInfo.DefaultThreadCurrentCulture   = cultura;
CultureInfo.DefaultThreadCurrentUICulture = cultura;

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Campanas}/{action=Index}/{id?}");

app.Run();
