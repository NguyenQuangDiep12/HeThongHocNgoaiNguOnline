using OELS.Core.Models.Enum;

namespace OELS.Core.Models
{
    public class QuizQuestion
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
        public string Question { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; }
        public int? Point { get; set; }
        public ICollection<QuizOption> Options { get; set; } = new List<QuizOption>();
        public ICollection<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
    }
}
