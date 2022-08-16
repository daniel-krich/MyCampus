using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class UserClassEntity : BaseEntity
    {
#nullable disable
        public Guid StudentId { get; set; }
        public virtual UserEntity Student { get; set; }
        public Guid ClassId { get; set; }
        public virtual ClassEntity Class { get; set; }
#nullable enable
        [MaxLength(100)]
        public string? Evaluation { get; set; }
    }
}