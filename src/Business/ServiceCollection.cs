using AutoMapper;
using Business.Dtos;
using Business.Services.Role;
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
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddDbContextFactory<QLGDContext>(contextOptionsBuilder)
                .AddScoped<IRoleService, RoleService>();
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<CreateRoleDto, IdentityRole>();
                CreateMap<UpateRoleDto, IdentityRole>();
                CreateMap<DeleteRoleDto, IdentityRole>();
            }
        }
    }
}
