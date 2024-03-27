using VideoRentShop.Data;
using VideoRentShop.Data.Implementations;
using VideoRentShop.Data.Implementations.Identity;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Data.Interfaces.Identity;
using VideoRentShop.Models.Identity;
using VideoRentShop.Services.Implementation.Identity;
using VideoRentShop.Services.Interfaces;
using VideoRentShop.Services.Interfaces.Identity;

namespace VideoRentShop.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationContext>(provider => provider.GetRequiredService<MainDbContext>());

            #region Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            #endregion

            return services;
        }
    }
}
