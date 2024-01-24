using GenericOData.Application.DbContexts.V1;
using GenericOData.Application.Models.V1.EdmModel;
using GenericOData.Application.Repositories.V1;
using GenericOData.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GenericOData.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void DependencyExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(PostgresRepository<>));
        }

        public static void PostgresConnectionExtension(this IServiceCollection services, string conn)
        {
            services.AddDbContext<ApiDbContext>(opt =>
            {
                opt.UseNpgsql(conn);
            });
        }
        public static void ODataExtension(this IServiceCollection services)
        {
            services.AddControllers()
                .AddOData(option =>
                {
                    option.AddRouteComponents("odata", GenerateEdmModel.GetEdmModel());
                    option.Select();
                    option.Filter();
                    option.OrderBy();
                    option.Count();
                    option.Expand();
                    option.SetMaxTop(null);
                });
        }

        public static void JwtAuthenticationExtension(this IServiceCollection services, string jwtIssuer, string jwtKey)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });
        }

        public static void SwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Valgenesis Generic API", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
                opt.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }
    }
}