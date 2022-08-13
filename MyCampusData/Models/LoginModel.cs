using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Models
{
    public class LoginModel
    {
        [Required, MinLength(5), MaxLength(30)]
        public string Username { get; set; } = "";
        [Required, MinLength(8), MaxLength(30)]
        public string Password { get; set; } = "";
        public bool RememberUser { get; set; }
        public void ClearFields()
        {
            Username = "";
            Password = "";
            RememberUser = false;
        }
    }
}
