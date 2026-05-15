namespace OELS.Core.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PassScore { get; set; }
        public int LimitTimeSec { get; set; }
        public int MaxAttempt {  get; set; }

        public ICollection<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
        public ICollection<QuizAttempt> Answers { get; set; } = new HashSet<QuizAttempt>();
        
    }
}
