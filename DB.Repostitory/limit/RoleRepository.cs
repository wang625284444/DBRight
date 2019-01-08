using DB.Entity;
using DB.Entity.Model;
using DB.IRepository.limit;

namespace DB.Repostitory.limit
{
    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(BaseDbContext Context) : base(Context)
        {
        }
    }
}
