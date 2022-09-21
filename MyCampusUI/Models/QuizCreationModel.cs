using System;
using System.ComponentModel.DataAnnotations;

namespace MyCampusUI.Models
{
    public class QuizCreationModel
    {
        [Required, MaxLength(50)]
        public string Title { get; set; } = "";
        public bool IsOpen { get; set; } = true;
        [ValidateComplexType]
        public List<QuizQuestionModel> Questions { get; set; } = new();

        public void AddQuestion()
        {
            Questions.Add(new QuizQuestionModel());
        }

        public void RemoveQuestion(QuizQuestionModel question)
        {
            Questions.Remove(question);
        }

        public bool HasValidAnswersAndQuestions()
        {
            return Questions.Count > 0 && Questions.All(x => x.Answers.Count(x => x.IsRight) == 1);
        }
    }

    public class QuizQuestionModel
    {
        [Required, MaxLength(80)]
        public string Question { get; set; } = "";
        [ValidateComplexType]
        public List<QuizAnswerModel> Answers { get; set; } = new();

        public void AddAnswer()
        {
            Answers.Add(new QuizAnswerModel());
        }

        public void RemoveAnswer(QuizAnswerModel answer)
        {
            Answers.Remove(answer);
        }
    }

    public class QuizAnswerModel
    {
        [Required, MaxLength(80)]
        public string Answer { get; set; } = "";
        public bool IsRight { get; set; }
    }
}
