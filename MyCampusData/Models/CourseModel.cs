using MyCampusData.Entities;

namespace MyCampusData.Models
{
    public class CourseModel
    {
        public CourseEntity? Course { get; set; }
        public long ClassesCount { get; set; }
    }
}
