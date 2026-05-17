using OELS.Core.Models;
using OELS.Core.Repositories;

namespace OELS.Repository.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        public QuizRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
