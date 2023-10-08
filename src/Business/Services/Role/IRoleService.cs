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
        Task<List<IdentityRole>> GetAllRoles();
        Task<ResponseCreateRole> CreateRole(CreateRoleDto data);
        Task<ResponseDeleteRole> DeleteRole(string roleID);
        Task<ResponseUpdateRole> UpdateRole(UpateRoleDto data, string roleID);
    }
}
