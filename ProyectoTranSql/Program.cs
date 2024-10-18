using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using ProyectoTranSql.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar conexi�n a la base de datos SQL Server (sin contrase�a)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

// Agregar servicios
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthService>(); // Servicio de autenticaci�n

var app = builder.Build();

// Configuraci�n del pipeline de HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Usar HSTS para producci�n
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Aqu� se inyecta el servicio de navegaci�n
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Redirigir a la p�gina espec�fica al iniciar
app.Use(async (context, next) =>
{
    // Verificar si la solicitud es para la ra�z ("/")
    if (context.Request.Path == "/")
    {
        // Redirigir a la p�gina de Reservaci�n
        context.Response.Redirect("/login");
        return; // No continuar con la siguiente middleware
    }
    await next(); // Llama al siguiente middleware
});

app.Run();


