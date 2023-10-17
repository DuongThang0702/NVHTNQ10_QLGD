using Business.Dtos;
using Data.Entities;
using Data.Migrations;
using Data.Model;
using Data.Repositories.Teacher;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepo _teacherRepo;
        public TeacherService(ITeacherRepo teacherRepo)
        {
            _teacherRepo = teacherRepo;
        }
        public async Task<IdentityResult> CreateTeacher(CreateTeacherDto data)
        {
            var model = new CreateTeacherModel()
            {
                Email = data.Email,
                Password = data.Password,
            };
            var result = await _teacherRepo.CreateTeacher(model);
            return result;
        }

        public async Task<List<ApplicationUser>?> GetAllTeacher()
        {
            var result = await _teacherRepo.GetAll();
            if (result == null) return null;
            else return result;
        }

        public async Task<IdentityResult> UpdateInfo(UpdateInfoTeacherDto data, string userId)
        {
            var model = new UpdateTeacherModel()
            {
                Address = data.Address, 
                DateOfBirth = data.DateOfBirth,
                FirstName = data.FirstName,
                LastName = data.LastName,
                MainSubjectTaught = data.MainSubjectTaught,
                PhoneNumber = data.PhoneNumber,
                TaxCode = data.TaxCode
            };
            var result = await _teacherRepo.UpdateInfo(model, userId);
            return result;
        }
    }
}
