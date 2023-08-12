using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FallLady.Mood;
using FallLady.Mood.Application.Contract.Interfaces.Course;
using FallLady.Mood.Application.Contract.Interfaces.Teachers;
using FallLady.Mood.Application.Contract.Interfaces.Users;
using FallLady.Mood.Application.Services.Courses;
using FallLady.Mood.Application.Services.Teacher;
using FallLady.Mood.Application.Services.Users;
using FallLady.Mood.Framework.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis;
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

builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ITeacherService,TeacherSerivce>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("JwtSettings", options))
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("CookieSettings", options));

var app = builder.Build();

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
