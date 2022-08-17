using MyCampusData.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusUI.Models
{
    public class UpdateProfileModel
    {

        [MaxLength(30)]
        public string CurrentPassword { get; set; } = "";

        [MaxLength(30)]
        public string NewPassword { get; set; } = "";

        [Required, MinLength(2), MaxLength(30)]
        public string FirstName { get; set; } = "";

        [Required, MinLength(2), MaxLength(30)]
        public string LastName { get; set; } = "";

        [Required, MinLength(10), MaxLength(128)]
        public string Email { get; set; } = "";

        [Required, MinLength(10), MaxLength(16)]
        public string PhoneNumber { get; set; } = "";

        [Required, MinLength(5), MaxLength(32)]
        public string City { get; set; } = "";

        [Required]
        public GenderEnum? Gender { get; set; }
    }
}
