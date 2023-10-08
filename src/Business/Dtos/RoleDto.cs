﻿using System.ComponentModel.DataAnnotations;

namespace Business.Dtos
{
    public class CreateRoleDto
    {
        [Required]
        [MinLength(3)]
        public string? RoleName { get; set; }
    }

    public class UpateRoleDto : CreateRoleDto { }

    public class DeleteRoleDto
    {
        [Required]
        public string? RoleID { get; set; }
    }

    public class ResponseCreateRole
    {
        public string? Mes { get; set; }
        public bool Status { get; set; }
    }

    public class ResponseDeleteRole : ResponseCreateRole { }
    public class ResponseUpdateRole : ResponseCreateRole { }

}