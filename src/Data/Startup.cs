using Data.Repositories.Auth;
using Data.Repositories.Role;
using Data.Repositories.Student;
using Data.Repositories.Teacher;
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
                .AddScoped<IAuthRepo, AuthRepo>()
                .AddScoped<IStudentRepo, StudentRepo>()
                .AddScoped<ITeacherRepo, TeacherRepo>()
                .AddScoped<IUserRepo, UserRepo>();
        }
    }
}
