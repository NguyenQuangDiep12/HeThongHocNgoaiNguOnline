namespace OELS.Core.Models
{
    public class Certificate
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string CertCode { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}
