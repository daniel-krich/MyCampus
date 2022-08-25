using MyCampusUI.Models;

namespace MyCampusUI.Interfaces.Services
{
    public interface IQuizManagerService
    {
        Task CreateLecturerQuiz(Guid classId, QuizCreationModel quizCreation);
        Task DeleteLecturerQuiz(Guid classId, Guid quizId);
        Task ToggleQuizState(Guid classId, Guid quizId);
        Task SubmitQuiz(Guid quizId, float score);
    }
}
