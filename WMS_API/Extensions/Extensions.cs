using WMS_API.Persistence.IRepositories;
using WMS_API.Persistence.IServices;
using WMS_API.Persistence.Repositories;
using WMS_API.Persistence.Services;

namespace WMS_API.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();

            // Mapping
            services.AddAutoMapper(cfg => { }, typeof(BaseMappingProfile).Assembly);

            // Services
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped<ILocationsService, LocationsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRolesService, RolesService>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
