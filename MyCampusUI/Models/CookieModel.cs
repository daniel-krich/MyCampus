using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusUI.Models
{
    public class CookieModel
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }

        public CookieModel(string token, DateTime expireAt)
        {
            Token = token;
            ExpireAt = expireAt;
        }
    }
}
