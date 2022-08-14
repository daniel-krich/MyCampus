using MyCampusData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class UserEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(30)]
        public string Username { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }
        public GenderEnum Gender { get; set; }
        public UserPermissionsEnum Permissions { get; set; }
        public virtual ICollection<UserCourseEntity> Courses { get; set; }
        public virtual ICollection<CourseEntity> LecturingCourses { get; set; }
        public virtual ICollection<SessionEntity> Sessions { get; set; }

        [Required, MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        public string LastName { get; set; }

        [Required, MaxLength(128)]
        public string Email { get; set; }

        [Required, MaxLength(16)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(32)]
        public string Country { get; set; }

        [Required, MaxLength(32)]
        public string City { get; set; }
    }
}