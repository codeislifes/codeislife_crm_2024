
using codeislife.crm.data;
using codeislife.crm.identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CrmDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("CommonDb");
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("codeislife.crm.web.app"));
});

builder.Services.AddDbContext<CrmIdentityDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("CommonDb");
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("codeislife.crm.web.app"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<CrmIdentityDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Auth/AccessDenied");
    options.LoginPath = new PathString("/Auth/Login");
    options.LogoutPath = new PathString("/Auth/Logout");
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;

    options.Events = new CookieAuthenticationEvents
    {
        OnSigningOut = x =>
        {
            x.Response.Redirect("/Auth/Login");
            return Task.CompletedTask;
        },
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Index}/{id?}");

app.Run();
