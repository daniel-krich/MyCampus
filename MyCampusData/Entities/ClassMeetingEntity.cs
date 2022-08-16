using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassMeetingEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(56)]
        public string Title { get; set; }

        [Required, MaxLength(255)]
        public string MeetingUrl { get; set; }

        public Guid ClassId { get; set; }
        public virtual ClassEntity Class { get; set; }
        public Guid LecturerId { get; set; }
        public virtual UserEntity Lecturer { get; set; }
        public DateTime StartAt { get; set; }
    }
}
