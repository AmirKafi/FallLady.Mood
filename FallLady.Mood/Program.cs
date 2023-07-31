using Autofac;
using Autofac.Extensions.DependencyInjection;
using FallLady.Mood;
using FallLady.Mood.Application.Contract.Interfaces;
using FallLady.Mood.Application.Services.Course;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(b =>
        {
            b.RegisterModule(new AutofacModule());
        });
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICourseService,CourseService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
