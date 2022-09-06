using MyCampusData.Entities;
using MyCampusUI.Models;

namespace MyCampusUI.Interfaces.Services;

public interface ICourseManagerService
{
    Task CreateCourse(CourseCreationModel creationModel);
    Task<CourseEntity> UpdateCourse(Guid courseId, CourseCreationModel creationModel);
}
