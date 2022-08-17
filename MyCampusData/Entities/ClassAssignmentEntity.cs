using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassAssignmentEntity : BaseEntity
    {
#nullable disable
        [Required]
        public string Title { get; set; }
        [Required]
        public string AssignmentText { get; set; }
        public Guid ClassId { get; set; }
        public virtual ClassEntity Class { get; set; }
        public virtual ICollection<ClassAssignmentSubmissionEntity> AssignmentSubmissions { get; set; }
        public DateTime StartSubmissionAt { get; set; }
        public DateTime EndSubmissionAt { get; set; }
#nullable enable
        public Guid? AssignmentBundleId { get; set; }
        public virtual BundleFileEntity? AssignmentBundle { get; set; }
    }
}
