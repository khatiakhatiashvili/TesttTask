using FluentValidation.AspNetCore;
using TestTask.Core.Application.Services;
using TestTask.Infrastructure.Persistence.Implementations.Services;
using TestTask.Presentation.WebApi.Extentions.Services;
using static TestTask.Core.Application.Features.UserProfiles.Commands.CreateWatchListCommand;

namespace TestTask.Presentation.WebApi.Extentions
{
    public static class ServiceExtensions
    {  
        public static void AddThisLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Validator>());

            services.AddSwaggerServices();
        
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovieService, MovieService>();

        }
    }
}
