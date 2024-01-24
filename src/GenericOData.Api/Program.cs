using GenericOData.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.DependencyExtension();
builder.Services.ODataExtension();

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();
builder.Services.JwtAuthenticationExtension(jwtIssuer, jwtKey);

var conn = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.PostgresConnectionExtension(conn);

builder.Services.AddEndpointsApiExplorer();

builder.Services.SwaggerGenExtension();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


// Make the implicit Program class public so test projects can access it
public partial class Program { }