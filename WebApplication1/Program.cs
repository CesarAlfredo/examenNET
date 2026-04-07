using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar servicios
builder.Services.AddControllers();
builder.Services.AddOpenApi(); // Esto habilita el generador interno

var app = builder.Build();

// 2. Configurar el pipeline
if (app.Environment.IsDevelopment())
{
    // MapOpenApi() ahora debería aparecer sin errores
    app.MapOpenApi(); 
    
    // Interfaz visual de Scalar
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();