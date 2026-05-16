namespace OELS.Core.Models
{
    public class Language
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
