namespace OELS.Core.Models
{
    public class Section
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string title { get; set; }
        public int SortOrder { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
