using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Role
{
    public interface IRoleRepo
    {
        Task<List<IdentityRole>> GetAll();
        Task<IdentityResult> Create(string role);
        Task<IdentityResult> Delete(string roleId);
        Task<IdentityResult> Update(string roleId, string roleName);
    }
}
