using Microsoft.EntityFrameworkCore;
using OELS.Core.Models;
using OELS.Core.Models.Enum;
using OELS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)  
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByRoleAsync(Role role)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Role == role);
        }

        public async Task<IEnumerable<Certificate>> GetCertificatesAsync(Guid userId)
        {
            return (IEnumerable<Certificate>)await _context.Users.Include(u => u.Certificates).Where(u => u.Id == userId).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetEnrolledCoursesAsync(Guid userId)
        {
            return (IEnumerable<Course>) await _context.Users.Include(u => u.Courses).Where(u => u.Id == userId).ToListAsync();
        }

        public async Task<LessonProgress?> GetLessonProgressAsync(Guid userId, Guid LessonId)
        {
            return await _context.LessonsProgresses.FirstOrDefaultAsync(lp => lp.UserId == userId && lp.LessonId == LessonId);
        }

        public async Task<IEnumerable<QuizAttempt>> GetQuizAttemptsAsync(Guid userId, Guid QuizId)
        {
            return await _context.QuizAttempts.Where(qa => qa.UserId == userId && qa.QuizId == QuizId).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetTeacherCoursesAsync(Guid TeacherId)
        {
            return await _context.Courses.Where(c => c.TeacherId == TeacherId).ToListAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync(Guid TeacherId)
        {
            return await _context.Payments.Where(p => p.UserId == TeacherId).SumAsync(p => p.Amount);
        }

        public async Task<bool> HasPurchasedCourseAsync(Guid userId, Guid CourseId)
        {
            return await _context.Enrollments.AnyAsync(e => e.UserId == userId && e.CourseId == CourseId);
        }
    }
}
