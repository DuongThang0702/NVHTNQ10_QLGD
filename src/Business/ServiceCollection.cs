using AutoMapper;
using Business.Dtos;
using Business.Services.Auth;
using Business.Services.Role;
using Business.Services.Student;
using Business.Services.Teacher;
using Business.Services.User;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class ServiceCollection
    {
        public static IServiceCollection ConfigurationService(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> contextOptionsBuilder
        )
        {
            return services
                .ConfigurationRepo()
                .ConfigurationScoped()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddDbContextFactory<QLGDContext>(contextOptionsBuilder);
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CreateRoleDto, IdentityRole>();
                CreateMap<UpateRoleDto, IdentityRole>();
                CreateMap<DeleteRoleDto, IdentityRole>();
                CreateMap<ResetPasswordDto, ApplicationUser>();
                CreateMap<SignInDto, ApplicationUser>();
                CreateMap<UpdateInfoUserDto, ApplicationUser>();
                CreateMap<UpdateRoleUser, ApplicationUser>();
                CreateMap<BlockUserDto, ApplicationUser>();
                CreateMap<UpdateInfoUserDto, ApplicationUser>();
                CreateMap<UpdateInfoTeacherDto, ApplicationUser>();
                CreateMap<CreateTeacherDto, ApplicationUser>();
            }
        }
    }

    public static class ConfigScope
    {
        public static IServiceCollection ConfigurationScoped(this IServiceCollection services)
        {
            return services
                .AddScoped<IRoleService, RoleService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IStudentService, StudentService>()
                .AddScoped<ITeacherService, TeacherService>()
                .AddScoped<IAuthService, AuthService>();
        }
    }
}
