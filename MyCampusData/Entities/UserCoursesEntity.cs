using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class UserCoursesEntity : BaseEntity
    {
#nullable disable
        public int StudentId { get; set; }
        public UserEntity Student { get; set; }
        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
        public float Grade { get; set; }
    }
}