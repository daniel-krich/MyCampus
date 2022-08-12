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
        [MaxLength(30)]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public GenderEnum Gender { get; set; }
        public UserPermissionsEnum Permissions { get; set; }
        public virtual ICollection<UserCoursesEntity> Courses { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }
        [MaxLength(16)]
        public string PhoneNumber { get; set; }
        [MaxLength(32)]
        public string Country { get; set; }
        [MaxLength(32)]
        public string City { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}