using DB.Entity;
using DB.Entity.Model;
using DB.IRepository.limit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Repostitory.limit
{
    public class ModuleRepository : BaseRepository<ModuleEntity>, IModuleRepository
    {
        public ModuleRepository(BaseDbContext Context) : base(Context)
        {

        }
    }
}
