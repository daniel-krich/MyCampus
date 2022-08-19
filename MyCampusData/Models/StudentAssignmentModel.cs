using MyCampusData.Entities;

namespace MyCampusData.Models
{
    public class StudentAssignmentModel
    {
        public ClassEntity? Class { get; set; }
        public ClassAssignmentEntity? Assignment { get; set; }
        public CourseEntity? Course { get; set; }
        public ClassAssignmentSubmissionEntity? AssignmentSubmission { get; set; }
    }
}
