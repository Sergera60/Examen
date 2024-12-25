using AM.ApplicationCore.Interfaces;
using AM.Infrastructure;
using Examen.ApplicationCore.Interfaces;
using Examen.ApplicationCore.Services;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbContext, ExamContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceColis,ServiceColis >();
builder.Services.AddScoped<IServiceLivreur, ServiceLivreur>();
builder.Services.AddScoped<IServiceClient, ServiceClient>();

builder.Services.AddSingleton<Type>(t => typeof(GenericRepository<>));








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
