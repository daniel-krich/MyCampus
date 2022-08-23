using MyCampusData.Entities;

namespace MyCampusData.Models
{
    public class ClassQuizModel
    {
        public ClassQuizEntity? Quiz { get; set; }
        public long QuizSubmissionsCount { get; set; }
    }
}
