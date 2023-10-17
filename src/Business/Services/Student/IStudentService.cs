using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Student
{
    public interface IStudentService
    {
        Task<List<ApplicationUser>?> GetAllStudent();
    }
}
