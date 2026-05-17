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
    public class QuizAnswerRepository : GenericRepository<QuizAnswer>, IQuizAnswerRepository
    {
        private readonly ApplicationDbContext _context;
        public QuizAnswerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
