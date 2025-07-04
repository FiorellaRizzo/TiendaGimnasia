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
        Title = "Gestión de Productos - AV Rítmica",
        Version = "v1",
        Description = "API para gestión de categorías de la Tienda de Gimnasia"
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
        c.RoutePrefix = string.Empty; // <- Esta línea hace que Swagger esté en /
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();