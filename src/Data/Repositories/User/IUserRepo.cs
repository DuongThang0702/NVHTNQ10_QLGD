using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.User
{
    public interface IUserRepo
    {
        Task<List<ApplicationUser>> GetAll();
        Task<IdentityResult> Delete(string userId);
    }
}
