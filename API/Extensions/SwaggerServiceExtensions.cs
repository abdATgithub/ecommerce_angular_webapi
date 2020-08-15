using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            return services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo {Title = "e-commerce API", Version = "v1"});

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                swagger.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirements = new OpenApiSecurityRequirement {{securitySchema, new [] {"Bearer"}}};
                swagger.AddSecurityRequirement(securityRequirements);
            });
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s => 
                { 
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "e-commerce API v1");
                });
            return app;
        }
    }
}