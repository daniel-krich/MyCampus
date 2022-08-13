using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class CourseAssignmentSubmissionEntity : BaseEntity
    {
#nullable disable
        public Guid StudentId { get; set; }
        public virtual UserEntity Student { get; set; }
        public Guid AssignmentId { get; set; }
        public virtual CourseAssignmentEntity Assignment { get; set; }
        [Required]
        public string SubmissionText { get; set; }
        public string SubmissionFileUrl { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
