using DB.Entity;
using DB.Entity.Model;
using DB.IRepository.limit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Repostitory.limit
{
    public class UserRoleRepository: BaseRepository<UserRoleEntity>, IUserRoleRepository
    {
        public UserRoleRepository(BaseDbContext Context) : base(Context)
        {
        }
    }
}
