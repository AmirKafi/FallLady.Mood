using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FallLady.Mood;
using FallLady.Mood.Application.Contract.Interfaces.Blogs;
using FallLady.Mood.Application.Contract.Interfaces.Categories;
using FallLady.Mood.Application.Contract.Interfaces.Course;
using FallLady.Mood.Application.Contract.Interfaces.Orders;
using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Application.Contract.Interfaces.Transactions;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Application.Services.Blogs;
using FallLady.Mood.Application.Services.Categories;
using FallLady.Mood.Application.Services.Courses;
using FallLady.Mood.Application.Services.Orders;
using FallLady.Mood.Application.Services.Teacher;
using FallLady.Mood.Application.Services.Transactions;
using FallLady.Mood.Application.Services.Users;
using FallLady.Mood.Domain.Domain.Users;
using FallLady.Mood.Framework.Core;
using FallLady.Mood.Utility;
using FallLady.Persistance;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(b =>
        {
            b.RegisterModule(new AutofacModule());
        });
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IConfigurationRoot>(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ITeacherService,TeacherSerivce>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
                      policy.RequireClaim("UserRole", "Admin"));
});

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
});

builder.Services.AddDbContext<FallLadyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddErrorDescriber<CustomIdentityError>();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = false;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
});


builder.Services.AddAuthorization();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.ExpireTimeSpan = TimeSpan.FromHours(170);
    option.LoginPath = "/Login";
    option.SlidingExpiration = true;
    
});

var app = builder.Build();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var identity = serviceScope.ServiceProvider.GetRequiredService<IdentityContext>();
    identity.Database.Migrate();

    var context = serviceScope.ServiceProvider.GetRequiredService<FallLadyDbContext>();
    context.Database.Migrate();
}

var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json",false)
            .Build();
var settings = config.GetSection("ApplicationSettings").Get<ApplicationSettingsModel>();
config.Bind(settings);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
