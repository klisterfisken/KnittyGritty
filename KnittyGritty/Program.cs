using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KnittyGritty.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<KnittyGrittyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("KnittyGrittyContext") ?? throw new InvalidOperationException("Connection string 'KnittyGrittyContext' not found.")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<KnittyGrittyContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
