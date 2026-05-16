namespace OELS.Core.Models
{
    public class QuizAnswer
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid QuestionId { get; set; }
        public QuizQuestion Question { get; set; } = null!;
        public Guid AttemptId { get; set; }
        public QuizAttempt Attempt { get; set; } = null!;
        public Guid SelectedOptionId { get; set; }
        public QuizOption SelectedOption { get; set; } = null!;
        public string AnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int PointEarned {  get; set; }
    }
}
