using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ProyectoTranSql.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar conexión a la base de datos SQL Server (sin contraseña)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

// Agregar servicios
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthService>(); // Servicio de autenticación

var app = builder.Build();

// Configuración del pipeline de HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Usar HSTS para producción
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Aquí se inyecta el servicio de navegación
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Redirigir a la página específica al iniciar
app.Use(async (context, next) =>
{
    // Verificar si la solicitud es para la raíz ("/")
    if (context.Request.Path == "/")
    {
        // Redirigir a la página de Reservación
        context.Response.Redirect("/login");
        return; // No continuar con la siguiente middleware
    }
    await next(); // Llama al siguiente middleware
});

app.Run();


