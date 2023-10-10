using Business.Dtos;
using Data.Repositories.Role;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;

        public RoleService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            var result = await _roleRepo.GetAll();
            return result;
        }

        public async Task<ResponseCreateRole> CreateRole(CreateRoleDto data)
        {
            if (string.IsNullOrEmpty(data.RoleName) || data == null)
                return new ResponseCreateRole { Mes = "Missing input", Status = false };

            var response = await _roleRepo.Create(data.RoleName);

            if (!response.Succeeded)
                return new ResponseCreateRole { Mes = "The role already exists", Status = false };

            return new ResponseCreateRole { Mes = "Role created successfully", Status = true };
            ;
        }

        public async Task<ResponseDeleteRole> DeleteRole(string roleId)
        {
            if (string.IsNullOrEmpty(roleId))
                return new ResponseDeleteRole { Mes = "Missing input", Status = false };
            var result = await _roleRepo.Delete(roleId);
            if (!result.Succeeded)
                return new ResponseDeleteRole { Mes = "RoleId not found", Status = false };
            else
                return new ResponseDeleteRole { Mes = "Role deleted successfully", Status = true };
        }

        public async Task<ResponseUpdateRole> UpdateRole(UpateRoleDto data, string roleID)
        {
            if (
                data == null
                || string.IsNullOrEmpty(roleID)
                || string.IsNullOrEmpty(data.RoleName)
            )
                return new ResponseUpdateRole { Mes = "Missing input", Status = false };
            var result = await _roleRepo.Update(roleID, data.RoleName);
            if (!result.Succeeded)
                return new ResponseUpdateRole { Mes = "RoleId not found", Status = false };
            else
                return new ResponseUpdateRole { Mes = "Role updated successfully", Status = true };
        }
    }
}
