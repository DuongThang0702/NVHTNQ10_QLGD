using Business.Dtos;
using Data.Repositories.Role;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly IRole _roleRepo;
        public RoleService(IRole roleRepo)
        {
            _roleRepo = roleRepo;
        }
        public Task<IdentityResult> CreateRole(CreateRoleDto roleName)
        {
            var response = _roleRepo.Create(roleName.RoleName);
            return response;
        }

        public Task<IdentityResult> DeleteRole()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateRole()
        {
            throw new NotImplementedException();
        }
    }
}
