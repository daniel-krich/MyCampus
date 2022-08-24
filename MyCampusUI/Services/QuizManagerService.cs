using Microsoft.EntityFrameworkCore;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusData.Enums;
using MyCampusUI.Exceptions;
using MyCampusUI.Interfaces.Services;
using MyCampusUI.Models;

namespace MyCampusUI.Services
{
    public class QuizManagerService : IQuizManagerService
    {
        private readonly IDbContextFactory<CampusContext> _campusContextFactory;
        private readonly IAuthenticationStateService _authenticationState;
        public QuizManagerService(IDbContextFactory<CampusContext> campusContextFactory, IAuthenticationStateService authenticationState, IBundleFilesService bundleService)
        {
            _campusContextFactory = campusContextFactory;
            _authenticationState = authenticationState;
        }

        public async Task CreateLecturerQuiz(Guid classId, QuizCreationModel quizCreation)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.User?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    if (user is not null && user.Permissions == UserPermissionsEnum.Lecturer)
                    {
                        var classEntity = await dbContext.Classes.FindAsync(classId);

                        if (classEntity != null)
                        {
                            var quiz = new ClassQuizEntity
                            {
                                Title = quizCreation.Title,
                                ClassId = classEntity.Id,
                                IsOpen = quizCreation.IsOpen,
                                Questions = new List<ClassQuizQuestionEntity>()
                            };

                            var questionsWithAnswersEntities = quizCreation.Questions.Select(x => new
                            {
                                question = new ClassQuizQuestionEntity
                                {
                                    Question = x.Question,
                                    QuizId = quiz.Id
                                },
                                answers = x.Answers.Select(y => new ClassQuizAnswerEntity
                                {
                                    Answer = y.Answer,
                                    IsRight = y.IsRight,
                                }).ToList()
                            }).ToList();

                            foreach(var questionWithAnswers in questionsWithAnswersEntities)
                            {
                                foreach(var answer in questionWithAnswers.answers)
                                {
                                    answer.QuestionId = questionWithAnswers.question.Id;
                                }
                                questionWithAnswers.question.Answers = questionWithAnswers.answers;
                                quiz.Questions.Add(questionWithAnswers.question);
                            }

                            dbContext.ClassQuizzes.Add(quiz);

                            await dbContext.SaveChangesAsync();
                            return;
                        }
                    }
                }
                throw new QuizCreateException("שגיאה באת יצירת החידון, אין מספיק הרשאות או שאירעה שגיאה קריטית");
            }
        }

        public async Task DeleteLecturerQuiz(Guid classId, Guid quizId)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.User?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    if (user is not null && user.Permissions == UserPermissionsEnum.Lecturer)
                    {
                        var quizEntity = await(from quiz in dbContext.ClassQuizzes
                                               where quiz.Id == quizId && quiz.ClassId == classId
                                               select quiz).FirstOrDefaultAsync();

                        if (quizEntity != null)
                        {
                            dbContext.ClassQuizzes.Remove(quizEntity);
                            await dbContext.SaveChangesAsync();
                            return;
                        }
                    }
                }
                throw new QuizDeleteException("שגיאה באת מחיקת החידון, החידון לא נימצא או שאין מספיק הרשאות");
            }
        }

        public async Task ToggleQuizState(Guid classId, Guid quizId)
        {
            using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
            {
                if (_authenticationState.User?.Id is Guid UserId)
                {
                    var user = await dbContext.Users.FindAsync(UserId);
                    if (user is not null && user.Permissions == UserPermissionsEnum.Lecturer)
                    {
                        var quizEntity = await (from quiz in dbContext.ClassQuizzes
                                                where quiz.Id == quizId && quiz.ClassId == classId
                                                select quiz).FirstOrDefaultAsync();

                        if (quizEntity != null)
                        {
                            quizEntity.IsOpen = !quizEntity.IsOpen;
                            await dbContext.SaveChangesAsync();
                            return;
                        }
                    }
                }
                throw new QuizToggleStatusException("שגיאה באת שינוי הסטטוס של החידון, החידון לא נימצא או שאין מספיק הרשאות");
            }
        }
    }
}
