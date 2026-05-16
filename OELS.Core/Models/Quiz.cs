namespace OELS.Core.Models
{
    public class Quiz
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PassScore { get; set; }
        public int LimitTimeSec { get; set; }
        public int MaxAttempt {  get; set; }

        public ICollection<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
        public ICollection<QuizAttempt> Answers { get; set; } = new List<QuizAttempt>();
        
    }
}
