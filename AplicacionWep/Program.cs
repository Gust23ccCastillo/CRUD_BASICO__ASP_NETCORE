
using Microsoft.EntityFrameworkCore;
using Proyect_Crud.BLL.Services;
using Proyect_Crud.DAL.DataContext;
using Proyect_Crud.DAL.Repositories;
using Proyect_Crud.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//configuracion para sql server
builder.Services.AddDbContext<CRUD_ASPNET_CORE_BASICOContext>(z =>
{
    z.UseSqlServer(builder.Configuration.GetConnectionString("ConexionBD"));
});

//Injeccion de Dependencias
builder.Services.AddScoped<IGenericRepository<Contacto>, ContacRepository>();
builder.Services.AddScoped<IContacServices, ContactServices>();


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
