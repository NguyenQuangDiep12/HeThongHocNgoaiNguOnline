using OELS.Core.Models;
using OELS.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> IsEmailExistsAsync(string email);
        Task<bool> IsTeacherAsync(Guid userId);
        Task<bool> IsAdminAsync(Guid userId);
        Task<IEnumerable<Course>> GetEnrolledCoursesAsync(Guid userId);
        Task<bool> HasPurchasedCourseAsync(Guid userId, Guid CourseId);
        Task<decimal> GetLearningProgressAsync(Guid userId);
        Task<IEnumerable<Certificate>> GetCertificatesAsync(Guid userId);
        Task<IEnumerable<QuizAttempt>> GetQuizAttemptsAsync(Guid userId);
        // Teacher
        Task<IEnumerable<Course>> GetTeacherCoursesAsync(Guid TeacherId);
        Task<int> GetTotalStudentsAsync(Guid TeacherId);
        Task<decimal> GetTotalRevenueAsync(Guid TeacherId);


    }
}
