namespace OELS.Core.Models
{
    public class Section
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
