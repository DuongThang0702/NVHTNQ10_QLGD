using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;

        [DefaultValue(false)]
        public bool IsBlocked { get; set; }

        //Teacher
        public string TaxCode { get; set; } = string.Empty;
        public string MainSubjectTaught { get; set; } = string.Empty;
    }
}
