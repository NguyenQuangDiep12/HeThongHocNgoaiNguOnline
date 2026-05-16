namespace OELS.Core.Models
{
    public class Lesson
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid SectionId { get; set; }
        public Section Section { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
        public int DurationSecond { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<LessonProgress> LessonProgresses { get; set; } = new List<LessonProgress>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
