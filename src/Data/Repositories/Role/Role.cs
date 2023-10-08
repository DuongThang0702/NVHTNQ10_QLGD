using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Role
{
    public class Role : IRole
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public Role(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> Create(string role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role);
            if (existingRole != null) return IdentityResult.Failed();
            var newRole = new IdentityRole(role);
            var result = await _roleManager.CreateAsync(newRole);
            if (!result.Succeeded) return IdentityResult.Failed();
            return result;
        }

        public Task<IdentityResult> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> GetOneBy()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> Patch()
        {
            throw new NotImplementedException();
        }
    }
}
