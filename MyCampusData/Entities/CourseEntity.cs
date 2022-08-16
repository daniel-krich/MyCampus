using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class CourseEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(128)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
        public virtual ICollection<ClassEntity> Classes { get; set; }
    }
}
