using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassQuizSubmissionEntity : BaseEntity
    {
#nullable disable
        public Guid ExamId { get; set; }
        public virtual ClassQuizEntity Exam { get; set; }

        public Guid StudentId { get; set; }
        public virtual UserEntity Student { get; set; }

        public float Score { get; set; }
    }
}
