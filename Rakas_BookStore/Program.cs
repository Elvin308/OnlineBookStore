using Microsoft.EntityFrameworkCore;
using Rakas_BookStore.DataAccess;
using Rakas_BookStore.DataAccess.Data;
using Rakas_BookStore.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Rakas_BookStore.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add SQL Server service and map it to the applicationDbContext class and the default connection string
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//Dependency Injections:
builder.Services.AddScoped<IRepositoryWork,RepositoryWork>();
builder.Services.AddRazorPages(); //Add razor pages use
builder.Services.AddScoped<IEmailSender,EmailSender>();

//Add default paths for login, logout and access denied
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
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
app.UseAuthentication(); //Check that the user is authenticated before we give any sort of autherization
app.UseAuthorization();

app.MapRazorPages(); //Add razor pages mapping

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
