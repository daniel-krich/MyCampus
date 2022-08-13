using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class CourseAssignmentEntity : BaseEntity
    {
#nullable disable
        [Required]
        public string Title { get; set; }
        [Required]
        public string AssignmentSource { get; set; }
        public Guid CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public virtual ICollection<CourseAssignmentSubmissionEntity> AssignmentSubmissions { get; set; }
        public DateTime StartSubmissionAt { get; set; }
        public DateTime EndSubmissionAt { get; set; }
    }
}
