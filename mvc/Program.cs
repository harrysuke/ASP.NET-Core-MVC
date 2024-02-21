using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mvc.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<mvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("mvcContext") ?? throw new InvalidOperationException("Connection string 'mvcContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
