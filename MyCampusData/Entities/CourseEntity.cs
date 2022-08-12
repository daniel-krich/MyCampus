using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class CourseEntity : BaseEntity
    {
#nullable disable
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CourseStartAt { get; set; }
        public DateTime CourseFinishAt { get; set; }
        public virtual ICollection<UserCoursesEntity> Students { get; set; }
#nullable enable
        public int? LecturerId { get; set; }
        public UserEntity? Lecturer { get; set; }
    }
}
