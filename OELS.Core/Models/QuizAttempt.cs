namespace OELS.Core.Models
{
    public class QuizAttempt
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
        public int AttemptNumber { get; set; }
        public int Score { get; set; }
        public bool IsPassed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public ICollection<QuizAnswer> Answers { get; set; } = new List<QuizAnswer>();
    }
}
