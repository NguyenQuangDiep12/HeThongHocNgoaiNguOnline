namespace OELS.Core.Models
{
    public class QuizOption
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid QuestionId { get; set; }
        public QuizQuestion Question { get; set; } = null!;
        public string OptionText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int SortOrder { get; set; }
        public ICollection<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
    }
}
