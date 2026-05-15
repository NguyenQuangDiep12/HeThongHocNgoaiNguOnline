namespace OELS.Core.Models
{
    public class Certificate
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public string CertCode { get; set; }
        public DateTime IssuedAt { get; set; }
    }
}
