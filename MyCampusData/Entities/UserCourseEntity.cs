using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class UserCourseEntity : BaseEntity
    {
#nullable disable
        public Guid StudentId { get; set; }
        public virtual UserEntity Student { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public float Grade { get; set; }
    }
}