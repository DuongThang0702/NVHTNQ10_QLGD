﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class CreateTeacherDto
    {
        public string Email {  get; set; } = string.Empty;
        public string Password{  get; set; } = string.Empty;
    }

    public class UpdateInfoTeacherDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string TaxCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string MainSubjectTaught { get; set; } = string.Empty;
    }
}
