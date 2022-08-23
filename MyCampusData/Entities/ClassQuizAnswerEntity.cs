using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassQuizAnswerEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(80)]
        public string Answer { get; set; }
        public bool IsRight { get; set; }
        public Guid QuestionId { get; set; }
        public virtual ClassQuizQuestionEntity Question { get; set; }
    }
}
