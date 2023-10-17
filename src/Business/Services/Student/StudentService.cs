using Data.Entities;
using Data.Repositories.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public async Task<List<ApplicationUser>?> GetAllStudent()
        {
            var result = await _studentRepo.GetAll();
            if (result == null) return null;
            else return result;
        }
    }
}
