using DB.Entity.Model;
using DB.IRepository.limit;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using DB.Entity;
using System.Threading.Tasks;

namespace DB.Repostitory.limit
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(BaseDbContext Context) : base(Context)
        {
        }
    }
}
