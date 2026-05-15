using OELS.Core.Models.Enum;


namespace OELS.Core.Models
{
    public class Payment 
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Transaction_Ref { get; set; } = string.Empty;
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
