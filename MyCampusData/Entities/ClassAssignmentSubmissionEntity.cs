using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassAssignmentSubmissionEntity : BaseEntity
    {
#nullable disable
        public Guid StudentId { get; set; }
        public virtual UserEntity Student { get; set; }
        public Guid AssignmentId { get; set; }
        public virtual ClassAssignmentEntity Assignment { get; set; }
        [Required]
        public string SubmissionText { get; set; }
        public DateTime SubmittedAt { get; set; }
#nullable enable
        [MaxLength(20)]
        public string? LecturerEvaluation { get; set; }
        [MaxLength(1024)]
        public string? LecturerNotes { get; set; }
        public Guid? AssignmentSubmissionBundleId { get; set; }
        public virtual BundleFileEntity? AssignmentSubmissionBundle { get; set; }
    }
}
