using AutoMapper;
using TestTask.Core.Application;
using TestTask.Infrastructure.Persistence;
using TestTask.Presentation.WebApi.Extentions;

namespace TestTask.Presentation.WebApi.Infrastructure.StartupConfiguration
{
    public static class ServiceConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder) 
        {          
            //Add application
            builder.Services.AddApplication(builder.Configuration);          
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddThisLayer(builder.Configuration);

            //add mapper
            AddMapper(builder.Services);

            return builder;
        }
        private static void AddMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                var typeImplementation = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(x => typeof(Profile).IsAssignableFrom(x)
                && !x.Namespace.StartsWith("AutoMapper"));
                foreach (var profile in typeImplementation) { mc.AddProfile(Activator.CreateInstance(profile) as Profile); }
            });
            var mapper = mappingConfig.CreateMapper(); services.AddSingleton(mapper);
        }
    }
}
