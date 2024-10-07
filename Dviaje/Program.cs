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

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexi�n a la base de datos para Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(10, 4, 32)))
);

// Conexi�n a la base de datos para los repositorios
builder.Services.AddScoped<IDbConnection>(cr =>
    new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Identity personalizado
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<ErrorDescriberIdentity>();

// Correcci�n de rutas de Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// Soporte para p�ginas razor
builder.Services.AddRazorPages();

// Soporte para las validaciones de FluentValidation del lado del cliente
builder.Services.AddFluentValidationClientsideAdapters();

// Servicios EmailSender temporal Para Identity en los registros
builder.Services.AddScoped<IEmailSender, EmailSender>();

//EmailServicio
builder.Services.AddScoped<IEnvioEmail, EnvioEmail>();

// Inyecci�n de Repositorios
builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<IFavoritosRepository, FavoritoRepository>();
builder.Services.AddScoped<IPerfilRepository, PerfilRepository>();
builder.Services.AddScoped<IPqrsRepository, PqrsRepository>();
builder.Services.AddScoped<IPublicacionesRepository, PublicacionesRepository>();
builder.Services.AddScoped<IResenasRepository, ResenaRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IRestriccionesRepository, RestriccionesRepository>();
builder.Services.AddScoped<IServiciosRepository, ServiciosRepository>();

// Inyecci�n de Validadores
builder.Services.AddScoped<IValidator<PqrsCrearVM>, PqrsCrearVMValidator>();


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

// Agrega el mapeo de rutas a las p�ginas razor
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Dviaje}/{controller=Inicio}/{action=Index}/{id?}");

app.Run();
