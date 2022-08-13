using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class CourseMeetingEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(56)]
        public string Title { get; set; }

        [Required, MaxLength(128)]
        public string MeetingUrl { get; set; }

        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public Guid LecturerId { get; set; }
        public virtual UserEntity Lecturer { get; set; }
        public DateTime StartAt { get; set; }
    }
}
