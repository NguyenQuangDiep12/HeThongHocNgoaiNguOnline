using OELS.Core.Models.Enum;

namespace OELS.Core.Models
{
    public class User
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password_Hash { get; set; } = string.Empty;
        public string Avatar_Url { get; set; } = string.Empty;
        public Role Role { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<CourseReview> CourseReviews { get; set; } = new List<CourseReview>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
        public ICollection<LessonProgress> LessonsProgresses { get; set; } = new List<LessonProgress>();
    }
}
