using Microsoft.EntityFrameworkCore;
using NotasDisciplinarias.API.Data;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// ================================
// 🔹 DB CONTEXT
// ================================
builder.Services.AddDbContext<NotasDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// ================================
// 🔹 CORS (PERMITIR ANGULAR)
// ================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// ================================
// 🔹 SERVICES
// ================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ================================
// 🔹 APP
// ================================
var app = builder.Build();

// ================================
// 🔹 MIDDLEWARE
// ================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔥 CORS VA AQUÍ, ANTES DE AUTH Y MAPCONTROLLERS
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
