using Data.Entities;
using Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Teacher
{
    public class TeacherRepo : ITeacherRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public TeacherRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateTeacher(CreateTeacherModel model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                var error = new IdentityError { Code = "400", Description = "User already exists" };
                return IdentityResult.Failed(error);
            }
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Teacher");
                return result;
            }
            else
                return IdentityResult.Failed();
        }


        public async Task<List<ApplicationUser>?> GetAll()
        {
            var teachers = await _userManager.GetUsersInRoleAsync("Teacher");
            if (teachers == null) return null;
            else return teachers.ToList();
        }

        public async Task<IdentityResult> UpdateInfo(UpdateTeacherModel data, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                IdentityError errors = new() { Code = "400", Description = "User not found" };
                return IdentityResult.Failed(errors);
            }
            user.Address = data.Address;
            user.LastName = data.LastName;
            user.FirstName = data.FirstName;
            user.PhoneNumber = data.PhoneNumber;
            user.TaxCode = data.TaxCode;
            user.MainSubjectTaught = data.MainSubjectTaught;
            user.DateOfBirth = data.DateOfBirth;
            return await _userManager.UpdateAsync(user);
        }

    }
}
