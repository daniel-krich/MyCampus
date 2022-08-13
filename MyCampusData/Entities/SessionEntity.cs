using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class SessionEntity : BaseEntity
    {
#nullable disable
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
