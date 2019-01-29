

using DB.Entity;
using DB.Entity.Model;
using DB.IRepository.limit;

namespace DB.Repostitory.limit
{
    public class ModuleButtionRepository : BaseRepository<ModuleButtionEntity>, IModuleButtionRepository
    {
        public ModuleButtionRepository(BaseDbContext Context) : base(Context) { }
    }
}
