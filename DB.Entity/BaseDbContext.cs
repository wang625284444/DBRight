using DB.Entity.Model;
using DB.Entity.Workflow;
using Microsoft.EntityFrameworkCore;
namespace DB.Entity
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options) { }

        public DbSet<UserEntity> T_User { get; set; }

        public DbSet<RoleEntity> T_Role { get; set; }

        public DbSet<UserRoleEntity> T_UserRole { get; set; }

        public DbSet<ModuleEntity> T_Module { get; set; }

        public DbSet<ModuleButtionEntity> T_ModuleButtion { get; set; }

        public DbSet<RoleButtionEntity> T_RoleButtion { get; set; }

        public DbSet<RoleModuleEntity> T_RoleModule { get; set; }

        public DbSet<WorkflowConfigureEntity> T_WorkflowConfigure { get; set; }

        public DbSet<WorkflowProcessEntity> T_WorkflowProcess { get; set; }

       


    }
}
