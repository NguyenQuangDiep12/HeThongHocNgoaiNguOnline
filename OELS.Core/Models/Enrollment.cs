using OELS.Core.Models.Enum;

namespace OELS.Core.Models
{
    public class Enrollment
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public EnrollmentStatus Status { get; set; }
        public DateTime EnrolledAt { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
