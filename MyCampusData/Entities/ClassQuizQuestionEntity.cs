﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampusData.Entities
{
    public class ClassQuizQuestionEntity : BaseEntity
    {
#nullable disable
        [Required, MaxLength(80)]
        public string Question { get; set; }
        public Guid ExamId { get; set; }
        public virtual ClassQuizEntity Exam { get; set; }
        public virtual ICollection<ClassQuizAnswerEntity> Answers { get; set; }
    }
}
