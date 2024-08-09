using Dviaje.DataAccess.Data;
using Dviaje.DataAccess.Repository;
using Dviaje.DataAccess.Repository.IRepository;
using Dviaje.Services;
using Dviaje.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexi�n a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Identity personalizado
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Soporte para p�ginas razor
builder.Services.AddRazorPages();

// Servicios
builder.Services.AddScoped<IEmailSender, EmailSender>();

//EmailServicio
builder.Services.AddScoped<IEnvioEmail, EnvioEmail>();

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

// Agrega el mapeo de rutas a las p�ginas razor
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Dviaje}/{controller=Home}/{action=Index}/{id?}");

app.Run();
