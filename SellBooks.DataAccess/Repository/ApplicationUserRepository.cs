using SellBooks.DataAccess.Data;
using SellBooks.DataAccess.Repository.IRepository;
using SellBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SellBooks.DataAccess.Repository
{
    public class ApplicationUserRepository :Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
