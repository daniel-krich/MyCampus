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
                    var assignment = await dbContext.ClassAssignments.FirstOrDefaultAsync(x => x.Id == assignmentId);
                    if (user is not null && assignment is not null)
                    {
                        var assignmentSub = await dbContext.ClassAssignmentSubmissions.FirstOrDefaultAsync(x => x.AssignmentId == assignmentId && x.StudentId == user.Id);

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

        public async Task<ClassAssignmentEntity> UpdateLecturerAssignment(Guid assignmentId, AssignmentCreationModel assignmentCreation, IReadOnlyList<IBrowserFile>? requestedUploadFiles, CancellationToken cancelToken = default)
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
                    }
                }
            }
            throw new AssignmentCreateUpdateException("שגיאה באת עדכון המשימה, יכול להיות שהמשימה אינה קיימת, נסו שוב עוד כמה רגעים");
        }

        public async Task<ClassAssignmentEntity> CreateLecturerAssignment(Guid classId, AssignmentCreationModel assignmentCreation, IReadOnlyList<IBrowserFile>? requestedUploadFiles, CancellationToken cancelToken = default)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.DisposedUserEntity?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    if (user is not null && user.Permissions == UserPermissionsEnum.Lecturer)
                    {
                        var classEntity = await dbContext.Classes.FindAsync(classId);

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
                    }
                }
            }
            throw new AssignmentCreateUpdateException("שגיאה באת יצירת המשימה, יכול להיות שהכיתה אינה קיימת, נסו שוב עוד כמה רגעים");
        }

        public async Task DeleteLecturerAssignment(Guid classId, Guid assignmentId)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.DisposedUserEntity?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    if (user is not null && user.Permissions == UserPermissionsEnum.Lecturer)
                    {
                        var assignment = await dbContext.ClassAssignments.Include(x => x.AssignmentSubmissions)
                                                                         .ThenInclude(x => x.AssignmentSubmissionBundle)
                                                                         .Include(x => x.AssignmentBundle)
                                                                         .FirstOrDefaultAsync(x => x.Id == assignmentId && x.ClassId == classId);
                        if (assignment != null)
                        {

                            if (assignment.AssignmentBundle != null)
                            {
                                await _bundleService.DeleteBundleAsync(assignment.AssignmentBundle.Id);
                                dbContext.Bundles.Remove(assignment.AssignmentBundle);
                            }

                            foreach(var assignmentSubmission in assignment.AssignmentSubmissions)
                            {
                                if (assignmentSubmission.AssignmentSubmissionBundle != null)
                                {
                                    await _bundleService.DeleteBundleAsync(assignmentSubmission.AssignmentSubmissionBundle.Id);
                                    dbContext.Bundles.Remove(assignmentSubmission.AssignmentSubmissionBundle);
                                }
                                dbContext.ClassAssignmentSubmissions.Remove(assignmentSubmission);
                            }

                            dbContext.ClassAssignments.Remove(assignment);

                            await dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            throw new AssignmentDeleteException("שגיאה באת מחיקת המשימה, יכול להיות שהמזהה לא נכון או שהמשימה לא מקושרת לכיתה שהוזנה");
                        }
                    }
                }
            }
        }

        public async Task EvaluateAssignmentSubmission(Guid submissionId, AssignmentEvaluationModel assignmentEvaluation)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.DisposedUserEntity?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    if (user is not null && user.Permissions == UserPermissionsEnum.Lecturer)
                    {
                        var submission = await dbContext.ClassAssignmentSubmissions.FindAsync(submissionId);
                        if (submission != null)
                        {
                            submission.LecturerEvaluation = assignmentEvaluation.Evaluation;
                            submission.LecturerNotes = assignmentEvaluation.Notes;
                            dbContext.ClassAssignmentSubmissions.Update(submission);
                            await dbContext.SaveChangesAsync();
                        }
                        else
                        {
                            throw new AssignmentSubmissionEvaluationException("שגיאה באת בדיקת המשימה, המשימה שהוגשה לא נמצאה");
                        }
                    }
                }
            }
        }
    }
}
