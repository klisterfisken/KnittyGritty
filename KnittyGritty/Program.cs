using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KnittyGritty.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<KnittyGrittyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KnittyGrittyContext") ?? throw new InvalidOperationException("Connection string 'KnittyGrittyContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[] { new System.Globalization.CultureInfo("en-US") };
app.UseRequestLocalization(new Microsoft.AspNetCore.Builder.RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthorization(); - lägg till senare

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
