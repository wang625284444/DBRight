using DB.Entity;
using DB.Entity.Model;
using DB.IRepository.limit;

namespace DB.Repostitory.limit
{
    public class RoleModuleRepository : BaseRepository<RoleModuleEntity>, IRoleModuleRepository
    {
        public RoleModuleRepository(BaseDbContext Context) : base(Context)
        {
        }
    }
}
