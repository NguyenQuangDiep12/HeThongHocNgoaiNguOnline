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
        // Dang nhap - Tim theo Email
        Task<User?> GetByEmailAsync(string email);
        // Loc theo Role - danh cho Admin
        Task<User> GetByRoleAsync(Role role);
    }
}
