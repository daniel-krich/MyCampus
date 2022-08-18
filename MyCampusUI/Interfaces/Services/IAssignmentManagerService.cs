using Microsoft.AspNetCore.Components.Forms;
using MyCampusData.Entities;
using MyCampusUI.Models;

namespace MyCampusUI.Interfaces.Services
{
    public interface IAssignmentManagerService
    {
        Task<ClassAssignmentSubmissionEntity> SubmitAssignment(Guid assignmentId, AssignmentSubmitModel assignmentSubmit, IReadOnlyList<IBrowserFile>? requestedUploadFiles, CancellationToken cancelToken = default);
    }
}