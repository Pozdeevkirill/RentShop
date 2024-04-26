using Microsoft.AspNetCore.Diagnostics;
using VideoRentShop.Data;
using VideoRentShop.Data.Implementations;
using VideoRentShop.Data.Implementations.Identity;
using VideoRentShop.Data.Interfaces;
using VideoRentShop.Data.Interfaces.Identity;
using VideoRentShop.Services.Implementation.Identity;
using VideoRentShop.Services.Implementation.ShopServices;
using VideoRentShop.Services.Interfaces.Identity;
using VideoRentShop.Services.Interfaces.ShopServices;

namespace VideoRentShop.WEB
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {

            #region Common
            services.AddScoped<IApplicationContext>(provider => provider.GetRequiredService<MainDbContext>());
            #endregion

            #region Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Services
            services.AddSingleton<IIdentityService, IdentityService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IWebAuthService, WebAuthService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IFileAttachmentService, FileAttachmentService>();
            services.AddScoped<IUserService, UserService>();
			#endregion

			return services;
        }
    }
}
