using MVCNewsAggregator.Core.Interfaces.Data;
using MVCNewsAgreggator.Data;
using MVCNewsAgreggator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNewsAggregator.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsAggregatorContext _db;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Source> _sourceRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole> _userRoleRepository;

        public UnitOfWork(NewsAggregatorContext context,
            IRepository<Article> articleRepository,
            IRepository<Source> sourceRepository,
            IRepository<Comment> commentRepository,
            IRepository<User> userRepository,
            IRepository<Role> roleRepository,
            IRepository<UserRole> userRoleRepository)
        {
            _db = context;
            _articleRepository = articleRepository;
            _sourceRepository = sourceRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            
        }

        public IRepository<Article> Articles => _articleRepository;
        public IRepository<Role> Roles => _roleRepository;
        public IRepository<User> Users => _userRepository;
        public IRepository<Source> Sources => _sourceRepository;
        public IRepository<Comment> Comments => _commentRepository;
        public IRepository<UserRole> UserRoles => _userRoleRepository;

        public UnitOfWork(NewsAggregatorContext context)
        {
            _db = context; 
        }

            public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
