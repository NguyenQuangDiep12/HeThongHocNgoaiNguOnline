namespace OELS.Core.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public Guid SectionId { get; set; }
        public Section Section { get; set; } = null!;
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public int DurationSecond { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
