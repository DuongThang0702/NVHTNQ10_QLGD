using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Student
{
    public class StudentRepo : IStudentRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<ApplicationUser>?> GetAll()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");
            if (students == null) return null;
            else return students.ToList();
        }
    }
}
