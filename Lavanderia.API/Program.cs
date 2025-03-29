using Lavanderia.Bussines.Interfaces;
using Lavanderia.Bussines.Mappings;
using Lavanderia.Bussines.Services.SAuth;
using Lavanderia.Bussines.Services.SClientes;
using Lavanderia.Bussines.Services.SOrdenes;
using Lavanderia.Bussines.Services.SProductos;
using Lavanderia.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<LavanderiaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cadena"))
);

#region Servicios
builder.Services.AddScoped<SCliente>();
builder.Services.AddScoped<SProductos>();
builder.Services.AddScoped<SAuth>();
builder.Services.AddScoped<SOrdenes>();
//builder.Services.AddScoped
#endregion
//builder.Services.AddSingleton<>
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string key = builder.Configuration["Jwt:Key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
