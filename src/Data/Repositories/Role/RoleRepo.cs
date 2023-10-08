using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Role
{
    public class RoleRepo : IRoleRepo
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepo(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> GetAll()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<IdentityResult> Create(string role)
        {
            var existingRole = await _roleManager.FindByNameAsync(role);
            if (existingRole != null)
                return IdentityResult.Failed();
            var newRole = new IdentityRole(role);
            var result = await _roleManager.CreateAsync(newRole);
            if (!result.Succeeded)
                return IdentityResult.Failed();
            return result;
        }

        public async Task<IdentityResult> Delete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return IdentityResult.Failed();
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<IdentityResult> Update(string roleId, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return IdentityResult.Failed();

            role.Name = roleName;
            return await _roleManager.UpdateAsync(role);
        }
    }
}
