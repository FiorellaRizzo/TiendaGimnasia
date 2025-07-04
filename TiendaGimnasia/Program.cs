using Microsoft.EntityFrameworkCore;
using TiendaGimnasia.Data;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TiendaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaDb")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gesti�n de Productos - AV R�tmica",
        Version = "v1",
        Description = "API para gesti�n de categor�as de la Tienda de Gimnasia"
    });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tienda API v1");
        c.RoutePrefix = string.Empty; // <- Esta l�nea hace que Swagger est� en /
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();