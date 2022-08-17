﻿using System;
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
        [MaxLength(255)]
        public string SubmissionFileUrl { get; set; }
        public DateTime SubmittedAt { get; set; }
#nullable enable
        [MaxLength(100)]
        public string? Evaluation { get; set; }
        public Guid? AssignmentSubmissionBundleId { get; set; }
        public virtual BundleFileEntity? AssignmentSubmissionBundle { get; set; }
    }
}
