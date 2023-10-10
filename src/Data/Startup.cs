using Data.Repositories.Role;
using Data.Repositories.User;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class Startup
    {
        public static IServiceCollection ConfigurationRepo(this IServiceCollection services)
        {
            return services
                .AddScoped<IRoleRepo, RoleRepo>()
                .AddScoped<IUserRepo, UserRepo>();
        }
    }
}
