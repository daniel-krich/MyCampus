using MyCampusData.Entities;

namespace MyCampusData.Models
{
    public class StudentQuizModel
    {
        public ClassQuizEntity? Quiz { get; set; }
        public ClassEntity? Class { get; set; }
        public CourseEntity? Course { get; set; }
        public ClassQuizSubmissionEntity? QuizSubmission { get; set; }
    }
}
