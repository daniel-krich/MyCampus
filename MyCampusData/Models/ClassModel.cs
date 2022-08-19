using MyCampusData.Entities;

namespace MyCampusData.Models
{
    public class ClassModel
    {
        public ClassEntity? Class { get; set; }
        public UserEntity? Lecturer { get; set; }
        public CourseEntity? Course { get; set; }
    }
}
