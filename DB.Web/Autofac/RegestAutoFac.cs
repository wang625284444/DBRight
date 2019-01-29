using Autofac;
using DB.IRepository.limit;
using DB.IService;
using DB.Repostitory.limit;
using DB.Service;
using DB.Utils.Extend;
using DB.Utils.Redis;

namespace DB.Web.Autofac
{
    public class RegestAutoFac : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextUtil>().As<HttpContextUtil>();
            builder.RegisterType<RedisCacheUtil>().As<RedisCacheUtil>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UsersService>().As<IUserService>();

            builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>();
            builder.RegisterType<UserRoleService>().As<IUserRoleService>();

            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<RoleService>().As<IRoleService>();

            builder.RegisterType<ModuleRepository>().As<IModuleRepository>();
            builder.RegisterType<ModuleService>().As<IModuleService>();

            builder.RegisterType<RoleModuleRepository>().As<IRoleModuleRepository>();
            builder.RegisterType<RoleModuleService>().As<IRoleModuleService>();

            builder.RegisterType<ModuleButtionRepository>().As<IModuleButtionRepository>();
            builder.RegisterType<ModuleButtionService>().As<IModuleButtionService>();

            builder.RegisterType<RoleButtionRepository>().As<IRoleButtionRepository>();
            builder.RegisterType<RoleButtionService>().As<IRoleButtionService>();
        }
    }
}
