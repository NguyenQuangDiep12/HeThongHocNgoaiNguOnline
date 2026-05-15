using OELS.Core.Models.Enum;

namespace OELS.Core.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; } = null!;
        public Guid TeacherId { get; set; }
        public User User { get; set; } = null!;
        public string Title { get; set; } 
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail_Url { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public ICollection<Payment> Payment { get; set; } = new List<Payment>();
        public ICollection<CourseReview> CourseReviews { get; set; } = new List<CourseReview>();
        public ICollection<Certificate> Certificates { get; set; } = new HashSet<Certificate>();
        public ICollection<Section> Sections { get; set; } = new List<Section>();

    }
}
