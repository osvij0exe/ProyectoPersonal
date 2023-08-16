using HospAPI;
using HospAPI.Servicios.interfaces;
using HospAPI.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
/*
 * configuracion EntityFrameworkCore SQL Server
 */
var connectionString = builder.Configuration.GetConnectionString("DefalutConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(connectionString));

//configuracion de ASP.NET Identity
builder.Services.AddDefaultIdentity<IdentityUser>(
    options =>
    {
        options.User.RequireUniqueEmail = true;

        options.SignIn.RequireConfirmedAccount = false;

        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireNonAlphanumeric = false;

        //tiempo de espera despues el bloque de cuentas
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //inentos antes de bloquear la cuenta
        options.Lockout.MaxFailedAccessAttempts = 5;
        //para los nuevos usuarios
        options.Lockout.AllowedForNewUsers = true;

    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//agregamos el servicio a la inyeccion de dependcia
builder.Services.AddTransient<IMedicosServices, MedicoServices>();
builder.Services.AddTransient<IPacienteService, PacientesServices>();
builder.Services.AddTransient<IInvestigacionesServices, InvestigacionServices>();

builder.Services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();
builder.Services.AddHttpContextAccessor();




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
app.MapRazorPages();

app.Run();
