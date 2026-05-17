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

        public async Task<User> GetByRoleAsync(Role role)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Role == role);
        }

        public Task<IEnumerable<Certificate>> GetCertificatesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetEnrolledCoursesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetLearningProgressAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<QuizAttempt>> GetQuizAttemptsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetTeacherCoursesAsync(Guid TeacherId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalRevenueAsync(Guid TeacherId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalStudentsAsync(Guid TeacherId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPurchasedCourseAsync(Guid userId, Guid CourseId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAdminAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public Task<bool> IsTeacherAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
