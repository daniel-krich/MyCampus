using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Models
{
    public class CookieModel
    {
        public bool IsSuccess { get; set; }
        public string? Token { get; set; }
        public DateTime ExpireAt { get; set; }

        public CookieModel(bool success)
        {
            IsSuccess = success;
        }

        public CookieModel(string token, DateTime expireAt) : this(true)
        {
            Token = token;
            ExpireAt = expireAt;
        }
    }
}
