using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(128)]
        public string Name { get; set; }
        public DateTime ClassStartAt { get; set; }
        public DateTime ClassFinishAt { get; set; }
        public virtual ICollection<UserClassEntity> Students { get; set; }
        public virtual ICollection<ClassMeetingEntity> Meetings { get; set; }
        public virtual ICollection<ClassAssignmentEntity> Assignments { get; set; }
        public virtual ICollection<ClassQuizEntity> Quizzes { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
#nullable enable
        public Guid? LecturerId { get; set; }
        public virtual UserEntity? Lecturer { get; set; }
    }
}
