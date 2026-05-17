using OELS.Core.Models;
using OELS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OELS.Repository.Repositories
{
    public class CourseReviewRepository : GenericRepository<CourseReview>, ICourseReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseReviewRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        
    }
}
