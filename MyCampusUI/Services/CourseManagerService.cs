using Microsoft.EntityFrameworkCore;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusData.Enums;
using MyCampusUI.Exceptions;
using MyCampusUI.Interfaces.Services;
using MyCampusUI.Models;

namespace MyCampusUI.Services;

public class CourseManagerService : ICourseManagerService
{
    private readonly IDbContextFactory<CampusContext> _campusContextFactory;
    private readonly IAuthenticationStateService _authenticationState;
    public CourseManagerService(IDbContextFactory<CampusContext> campusContextFactory, IAuthenticationStateService authenticationState)
    {
        _campusContextFactory = campusContextFactory;
        _authenticationState = authenticationState;
    }

    public async Task CreateCourse(CourseCreationModel creationModel)
    {
        using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
        {
            if (_authenticationState.User?.Id is Guid UserId)
            {
                var user = await dbContext.Users.FindAsync(UserId);
                if (user is not null && user.Permissions == UserPermissionsEnum.Staff)
                {
                    var course = new CourseEntity
                    {
                        Name = creationModel.Name,
                        Description = creationModel.Description
                    };
                    dbContext.Courses.Add(course);
                    await dbContext.SaveChangesAsync();
                    return;
                }
            }
            throw new CourseCreateUpdateException("שגיאה באת יצירת הקורס, אין מספיק הרשאות");
        }
    }

    public async Task<CourseEntity> UpdateCourse(Guid courseId, CourseCreationModel creationModel)
    {
        using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
        {
            if (_authenticationState.User?.Id is Guid UserId)
            {
                var user = await dbContext.Users.FindAsync(UserId);
                var course = await dbContext.Courses.FindAsync(courseId);
                if (user is not null && user.Permissions == UserPermissionsEnum.Staff)
                {
                    if(course is not null)
                    {
                        course.Name = creationModel.Name;
                        course.Description = creationModel.Description;
                        dbContext.Courses.Update(course);
                        await dbContext.SaveChangesAsync();
                        return course;
                    }
                    else
                    {
                        throw new CourseCreateUpdateException("שגיאה באת עדכון הקורס, הקורס לא נמצא");
                    }
                }
            }
            throw new CourseCreateUpdateException("שגיאה באת עדכון הקורס, אין מספיק הרשאות");
        }
    }
}
