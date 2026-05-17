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
        Task<IEnumerable<Course>> GetEnrolledCoursesAsync(Guid userId);
        Task<bool> HasPurchasedCourseAsync(Guid userId, Guid CourseId);
        Task<LessonProgress?> GetLessonProgressAsync(Guid userId, Guid LessonId);
        Task<IEnumerable<Certificate>> GetCertificatesAsync(Guid userId);
        Task<IEnumerable<QuizAttempt>> GetQuizAttemptsAsync(Guid userId, Guid QuizId);
        // Teacher
        Task<IEnumerable<Course>> GetTeacherCoursesAsync(Guid TeacherId);
        Task<decimal> GetTotalRevenueAsync(Guid TeacherId);


    }
}
