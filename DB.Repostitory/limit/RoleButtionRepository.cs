using DB.Entity;
using DB.Entity.Model;
using DB.IRepository.limit;

namespace DB.Repostitory.limit
{
    public class RoleButtionRepository: BaseRepository<RoleButtionEntity>, IRoleButtionRepository
    {
        public RoleButtionRepository(BaseDbContext Context) : base(Context) { }
    }
}
