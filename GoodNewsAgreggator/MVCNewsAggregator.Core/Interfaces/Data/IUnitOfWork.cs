using MVCNewsAgreggator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAggregator.Core.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Role> Roles { get; }
        IRepository<User> Users { get; }
        IRepository<Source> Sources { get; }
        IRepository<Comment> Comments { get; }
        IRepository<UserRole> UserRoles { get; }
        //IRepository<RefreshToken> RefreshTokens { get; }

        Task<int> Commit();
    }
}
