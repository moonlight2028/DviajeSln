using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Conexion a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("localDb"), new MariaDbServerVersion(new Version(10, 4, 32))));

//Identity personalizado
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//Agrega soporte a las paginas razor
builder.Services.AddRazorPages();

// Servicios
builder.Services.AddScoped<IEmailSender, EmailSender>();

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
app.UseAuthentication(); ;
app.UseAuthorization();

//Agrega el RoutingMap para paginas razor
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Dviaje}/{controller=Home}/{action=Index}/{id?}");

app.Run();
