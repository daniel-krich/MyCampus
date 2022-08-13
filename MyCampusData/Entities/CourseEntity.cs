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
        [Required, MaxLength(56)]
        public string Name { get; set; }
        [Required, MaxLength(256)]
        public string Description { get; set; }
        public DateTime CourseStartAt { get; set; }
        public DateTime CourseFinishAt { get; set; }
        public virtual ICollection<UserCourseEntity> Students { get; set; }
        public virtual ICollection<CourseMeetingEntity> Meetings { get; set; }
        public virtual ICollection<CourseAssignmentEntity> Assignments { get; set; }
#nullable enable
        public Guid? LecturerId { get; set; }
        public virtual UserEntity? Lecturer { get; set; }
    }
}
