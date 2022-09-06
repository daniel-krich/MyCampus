using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusUI.Models
{
    public class CourseCreationModel
    {
#nullable disable
        [Required, MaxLength(128)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Description { get; set; }
    }
}
