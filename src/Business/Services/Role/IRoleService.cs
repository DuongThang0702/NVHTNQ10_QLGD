using Business.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Role
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRole(CreateRoleDto roleName);
        Task<IdentityResult> GetAllRoles();
        Task<IdentityResult> GetById();
        Task<IdentityResult> DeleteRole();
        Task<IdentityResult> UpdateRole();
    }
}
