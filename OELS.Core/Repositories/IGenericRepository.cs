using System.Linq.Expressions;


namespace OELS.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Lay theo Id
        Task<T> GetByIdAsync(Guid Id);
        // Lay tat ca
        IQueryable<T> GetAll();
        // Loc co dieu kien
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        // Tim kiem co dieu kien thoa man
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        // Them T
        Task AddAsync(T entity);
        // Them danh sach T
        Task AddRangeAsync(IEnumerable<T> entities);
        // Cap Nhat T
        void Update(T entity);
        // Xoa Bo T
        void Remove(T entity);
        // Xoa bo mot danh sach
        void RemoveRange(IEnumerable<T> entities);
    }
}
