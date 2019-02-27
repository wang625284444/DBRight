using DB.Entity;
using DB.Entity.Model;
using DB.IRepository.limit;

namespace DB.Repostitory.limit
{
    public class UserRoleRepository: BaseRepository<UserRoleEntity>, IUserRoleRepository
    {
        public UserRoleRepository(BaseDbContext Context) : base(Context)
        {
        }
    }
}
