using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusData.Enums;
using MyCampusUI.Exceptions;
using MyCampusUI.Interfaces.Services;
using MyCampusUI.Models;

namespace MyCampusUI.Services
{
    public class AssignmentManagerService : IAssignmentManagerService
    {
        private readonly IDbContextFactory<CampusContext> _campusContextFactory;
        private readonly IAuthenticationStateService _authenticationState;
        private readonly IBundleFilesService _bundleService;
        public AssignmentManagerService(IDbContextFactory<CampusContext> campusContextFactory, IAuthenticationStateService authenticationState, IBundleFilesService bundleService)
        {
            _campusContextFactory = campusContextFactory;
            _authenticationState = authenticationState;
            _bundleService = bundleService;
        }

        public async Task<ClassAssignmentSubmissionEntity> SubmitAssignment(Guid assignmentId, AssignmentSubmitModel assignmentSubmit, IReadOnlyList<IBrowserFile>? requestedUploadFiles, CancellationToken cancelToken = default)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.DisposedUserEntity?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    var assignment = await dbContext.ClassAssignments.FindAsync(assignmentId);
                    if (user is not null && assignment is not null)
                    {
                        var assignmentSub = await assignment.AssignmentSubmissions.ToAsyncEnumerable().FirstOrDefaultAsync(x => x.StudentId == user.Id);

                        if (assignmentSub?.LecturerEvaluation == null)
                        {
                            if (assignmentSub != null)
                            {
                                assignmentSub.SubmissionText = assignmentSubmit.SubmissionText;
                                assignmentSub.SubmittedAt = DateTime.Now;

                                if (requestedUploadFiles != null)
                                {
                                    if (assignmentSub.AssignmentSubmissionBundleId.HasValue)
                                    {
                                        var rewriteResult = await _bundleService.RewriteBundleAsync(assignmentSub.AssignmentSubmissionBundleId.Value, requestedUploadFiles.ToArray(), cancelToken);
                                        if (!rewriteResult)
                                        {
                                            throw new AssignmentSubmitException("אירעה שגיאה באת העלאת הקבצים, בדקו שכל קובץ שוקל עד 2MB והמשקל הכולל לא עולה על 20MB");
                                        }
                                    }
                                    else
                                    {
                                        var bundleId = await _bundleService.CreateBundleAsync(requestedUploadFiles.ToArray(), cancelToken);
                                        if (bundleId.HasValue)
                                        {
                                            assignmentSub.AssignmentSubmissionBundleId = bundleId;
                                        }
                                        else
                                        {
                                            throw new AssignmentSubmitException("אירעה שגיאה באת העלאת הקבצים, בדקו שכל קובץ שוקל עד 2MB והמשקל הכולל לא עולה על 20MB");
                                        }
                                    }
                                }

                                dbContext.ClassAssignmentSubmissions.Update(assignmentSub);
                                await dbContext.SaveChangesAsync();
                                return assignmentSub;
                            }
                            else
                            {
                                var newSubmission = new ClassAssignmentSubmissionEntity
                                {
                                    StudentId = user.Id,
                                    AssignmentId = assignment.Id,
                                    SubmissionFileUrl = "https://none",
                                    SubmissionText = assignmentSubmit.SubmissionText,
                                    SubmittedAt = DateTime.Now
                                };
                                dbContext.ClassAssignmentSubmissions.Add(newSubmission);

                                if (requestedUploadFiles != null)
                                {
                                    var bundleId = await _bundleService.CreateBundleAsync(requestedUploadFiles.ToArray(), cancelToken);
                                    if (bundleId.HasValue)
                                    {
                                        newSubmission.AssignmentSubmissionBundleId = bundleId;
                                    }
                                    else
                                    {
                                        throw new AssignmentSubmitException("אירעה שגיאה באת העלאת הקבצים, בדקו שכל קובץ שוקל עד 2MB והמשקל הכולל לא עולה על 20MB");
                                    }
                                }

                                await dbContext.SaveChangesAsync();
                                return newSubmission;
                            }
                        }
                        else
                        {
                            throw new AssignmentSubmitException("המשימה כבר נבדקה ואינה יכולה להיות מוגשת");
                        }
                    }
                }
                throw new AssignmentSubmitException("אירעה שגיאה כללית באת הגשת המשימה, נסו שוב מאוחר יותר");
            }
        }

        public async Task<ClassAssignmentEntity> CreateOrUpdateLecturerAssignment(Guid assignmentId, AssignmentCreationModel assignmentCreation, IReadOnlyList<IBrowserFile>? requestedUploadFiles, Guid? classId = default, CancellationToken cancelToken = default)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.DisposedUserEntity?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    if (user is not null && user.Permissions == UserPermissionsEnum.Lecturer)
                    {
                        var assignment = await dbContext.ClassAssignments.FindAsync(assignmentId);

                        if (assignment != null)
                        {
                            assignment.Title = assignmentCreation.Title;
                            assignment.AssignmentText = assignmentCreation.AssignmentText;
                            assignment.EndSubmissionAt = assignmentCreation.EndSubmissionAt;

                            if (requestedUploadFiles != null)
                            {
                                if (assignment.AssignmentBundleId.HasValue)
                                {
                                    var rewriteResult = await _bundleService.RewriteBundleAsync(assignment.AssignmentBundleId.Value, requestedUploadFiles.ToArray(), cancelToken);
                                    if (!rewriteResult)
                                    {
                                        throw new AssignmentCreateUpdateException("אירעה שגיאה באת העלאת הקבצים, בדקו שכל קובץ שוקל עד 2MB והמשקל הכולל לא עולה על 20MB");
                                    }
                                }
                                else
                                {
                                    var bundleId = await _bundleService.CreateBundleAsync(requestedUploadFiles.ToArray(), cancelToken);
                                    if (bundleId.HasValue)
                                    {
                                        assignment.AssignmentBundleId = bundleId;
                                    }
                                    else
                                    {
                                        throw new AssignmentCreateUpdateException("אירעה שגיאה באת העלאת הקבצים, בדקו שכל קובץ שוקל עד 2MB והמשקל הכולל לא עולה על 20MB");
                                    }
                                }
                            }

                            dbContext.ClassAssignments.Update(assignment);
                            await dbContext.SaveChangesAsync();
                            return assignment;
                        }
                        else if(classId.HasValue)
                        {
                            var classEntity = await dbContext.Classes.FindAsync(classId.Value);

                            if (classEntity != null)
                            {

                                var newAssignment = new ClassAssignmentEntity
                                {
                                    Title = assignmentCreation.Title,
                                    AssignmentText = assignmentCreation.AssignmentText,
                                    EndSubmissionAt = assignmentCreation.EndSubmissionAt,
                                    ClassId = classEntity.Id
                                };

                                dbContext.ClassAssignments.Add(newAssignment);

                                if (requestedUploadFiles != null)
                                {
                                    var bundleId = await _bundleService.CreateBundleAsync(requestedUploadFiles.ToArray(), cancelToken);
                                    if (bundleId.HasValue)
                                    {
                                        newAssignment.AssignmentBundleId = bundleId;
                                    }
                                    else
                                    {
                                        throw new AssignmentCreateUpdateException("אירעה שגיאה באת העלאת הקבצים, בדקו שכל קובץ שוקל עד 2MB והמשקל הכולל לא עולה על 20MB");
                                    }
                                }

                                await dbContext.SaveChangesAsync();
                                return newAssignment;
                            }
                            else
                            {
                                throw new AssignmentCreateUpdateException("הכיתה שאליה אתם מנסים להוסיף את המשימה אינה קיימת");
                            }
                        }
                    }
                }
                throw new AssignmentCreateUpdateException("אירעה שגיאה כללית באת עדכון המשימה");
            }
        }
    }
}
