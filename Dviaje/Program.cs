using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Models.VM;
using Dviaje.Services;
using Dviaje.Services.IServices;
using Dviaje.Utility;
using Dviaje.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Conexión a la base de datos para Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(10, 4, 32)))
);

// Conexión a la base de datos para los repositorios
builder.Services.AddScoped<IDbConnection>(cr =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Identity personalizado
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    //options.SignIn.RequireConfirmedEmail = true;
    //options.SignIn.RequireConfirmedAccount = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<ErrorDescriberIdentityUtility>();

// Corrección de rutas de Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// Soporte para páginas razor
builder.Services.AddRazorPages();

// Soporte para las validaciones de FluentValidation del lado del cliente
builder.Services.AddFluentValidationClientsideAdapters();

// Inyección de Servicios
builder.Services.AddScoped<IEmailSender, SendGridService>();
builder.Services.AddScoped<IEnvioEmailService, SendGridService>();
builder.Services.AddScoped<ISubirArchivosService, CloudinaryService>();
builder.Services.AddScoped<IOptimizacionImagenesService, ImageSharpService>();

// Inyección de Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<ILandingPageRepository, LandingPageRepository>();
builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<IFavoritosRepository, FavoritoRepository>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
builder.Services.AddScoped<IPqrsRepository, PqrsRepository>();
builder.Services.AddScoped<IPublicacionesRepository, PublicacionesRepository>();
builder.Services.AddScoped<IResenasRepository, ResenaRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IRestriccionesRepository, RestriccionesRepository>();
builder.Services.AddScoped<IServiciosRepository, ServiciosRepository>();

// Inyección de Validadores
builder.Services.AddScoped<IValidator<PqrsCrearVM>, PqrsCrearAutenticadoVMValidator>();
builder.Services.AddScoped<IValidator<PqrsCrearVM>, PqrsCrearVMValidator>();
builder.Services.AddScoped<IValidator<IdentityPerfilVM>, IdentityPerfilVMValidator>();
builder.Services.AddScoped<IValidator<IdentityManageEmailVM>, IdentityManageEmailVMValidator>();
builder.Services.AddScoped<IValidator<IdentityManagePasswordVM>, IdentityManagePasswordVMValidator>();
builder.Services.AddScoped<IValidator<IdentityManageAliadoVM>, IdentityManageAliadoVMValidator>();


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

// Agrega el mapeo de rutas a las páginas razor
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Dviaje}/{controller=Inicio}/{action=Index}/{id?}");

app.Run();
