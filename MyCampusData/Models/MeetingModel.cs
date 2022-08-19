using MyCampusData.Entities;

namespace MyCampusData.Models
{
    public class MeetingModel
    {
        public ClassMeetingEntity? Meeting { get; set; }
        public CourseEntity? Course { get; set; }
        public ClassEntity? Class { get; set; }
        public UserEntity? Lecturer { get; set; }
    }
}
