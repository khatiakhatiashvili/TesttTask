using Microsoft.OpenApi.Models;

namespace TestTask.Presentation.WebApi.Extentions.Services
{
    public static class SwaggerConfigurationExtensions
    {

        // services
        public static void AddSwaggerServices(this IServiceCollection services, params string[] options)
        {
          
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.IgnoreObsoleteActions();
                c.IgnoreObsoleteProperties();
                c.CustomSchemaIds(type => type.FullName);

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                //// Define the security scheme and add it to Swagger
                //var securityScheme = new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    Description = "JWT Authorization header using the Bearer scheme",
                //};
                //c.AddSecurityDefinition("Bearer", securityScheme);

                // Use the security scheme in operations that require authorization
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }

            });
            });

        }
        // middleware
        //public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app, params string[] options)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(s =>
        //    {
        //        foreach (var name in options)
        //        {
        //            s.SwaggerEndpoint(
        //                url: $"{name}/swagger.json",
        //                name: name);
        //        }
        //    });

        //    return app;
        //}
    }
}
