namespace OELS.Core.Models
{
    public class LessonProgress
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
        public decimal CompletedPercent { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
