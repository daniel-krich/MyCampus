using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassQuizEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(50)]
        public string Title { get; set; }
        public Guid ClassId { get; set; }
        public virtual ClassEntity Class { get; set; }
        public bool IsOpen { get; set; }
        public virtual ICollection<ClassQuizQuestionEntity> Questions { get; set; }
        public virtual ICollection<ClassQuizSubmissionEntity> Submissions { get; set; }
    }
}
