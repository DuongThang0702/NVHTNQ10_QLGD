using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Role
{
    public interface IRole
    {
        Task<IdentityResult> Create(string role);
        Task<IdentityResult> GetAll();
        Task<IdentityResult> GetOneBy();
        Task<IdentityResult> Delete();
        Task<IdentityResult> Patch();

    }
}
