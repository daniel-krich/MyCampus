using MyCampusData.Entities;

namespace MyCampusData.Models
{
    public class ClassAssignmentModel
    {
        public ClassAssignmentEntity? Assignment { get; set; }
        public long AssignmentSubmissions { get; set; }
    }
}
