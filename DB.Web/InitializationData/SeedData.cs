using DB.Entity;
using DB.Entity.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using static DB.Entity.Enum.UserEnum;
using static DB.Entity.Enum.WorkflowEnum;

namespace DB.Web.InitializationData
{
    /// <summary>
    /// 添加初始化数据
    /// </summary>
    public class SeedData
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                BaseDbContext context = serviceScope.ServiceProvider.GetService<BaseDbContext>();
                //判断数据是否存在
                if (!context.T_User.Any())
                {
                    //添加用户
                    var user1 = context.T_User.Add(new UserEntity
                    {
                        Id = Guid.NewGuid(),
                        UserNumber = "010000001",
                        UserAccount = "admin",
                        UserPassword = "admin",
                        UserName = "admin",
                        PhoneNumber = "13000000000",
                        Mail = "mail@123.cn",
                        Status = StatusEnum.Normal,
                        WorkflowStatus = WorkflowStatus.ApprovalAndApproval
                    });
                    var user2 = context.T_User.Add(new UserEntity
                    {
                        Id = Guid.NewGuid(),
                        UserNumber = "010000002",
                        UserAccount = "admin1",
                        UserPassword = "admin1",
                        UserName = "admin",
                        PhoneNumber = "13000000000",
                        Mail = "mail@123.cn",
                        Status = StatusEnum.Normal,
                        WorkflowStatus = WorkflowStatus.ApprovalAndApproval
                    });



                    //角色信息
                    var role1 = context.T_Role.Add(new RoleEntity
                    {
                        Id = Guid.NewGuid(),
                        RoleName = "高级管理员",
                        Pid = new Guid("00000000-0000-0000-0000-000000000000"),
                        WorkflowStatus = WorkflowStatus.ApprovalAndApproval
                    });



                    //账号管理
                    var module1 = context.T_Module.Add(new ModuleEntity
                    {
                        Id = Guid.NewGuid(),
                        UrlName = "用户管理",
                        Pid = new Guid("00000000-0000-0000-0000-000000000000"),
                    });
                    //添加模块
                    context.T_RoleModule.Add(new RoleModuleEntity
                    {
                        Id = Guid.NewGuid(),
                        RoleId = role1.Entity.Id,
                        ModuleId = module1.Entity.Id,
                        WorkflowStatus = WorkflowStatus.ApprovalAndApproval
                    });
                    //添加按钮
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module1.Entity.Id,
                        ButtionName = "添加用户",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module1.Entity.Id,
                        ButtionName = "修改用户",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module1.Entity.Id,
                        ButtionName = "删除用户",
                    });


                    
                    //账号管理
                    var module2 = context.T_Module.Add(new ModuleEntity
                    {
                        Id = Guid.NewGuid(),
                        UrlName = "账号管理",
                        Url = "/User/Index",
                        Pid = module1.Entity.Id,
                    });
                    //添加模块
                    context.T_RoleModule.Add(new RoleModuleEntity
                    {
                        Id = Guid.NewGuid(),
                        RoleId = role1.Entity.Id,
                        ModuleId = module2.Entity.Id
                    });
                    //添加按钮
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module2.Entity.Id,
                        ButtionName = "添加账号",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module2.Entity.Id,
                        ButtionName = "修改账号",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module2.Entity.Id,
                        ButtionName = "删除账号",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module2.Entity.Id,
                        ButtionName = "分配角色",
                    });


                    //角色管理
                    var module3 = context.T_Module.Add(new ModuleEntity
                    {
                        Id = Guid.NewGuid(),
                        UrlName = "角色管理",
                        Url = "/Role/Index",
                        Pid = module1.Entity.Id,
                    });
                    //添加模块
                    context.T_RoleModule.Add(new RoleModuleEntity
                    {
                        Id = Guid.NewGuid(),
                        RoleId = role1.Entity.Id,
                        ModuleId = module3.Entity.Id
                    });
                    //添加按钮
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module3.Entity.Id,
                        ButtionName = "添加角色",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module3.Entity.Id,
                        ButtionName = "修改角色",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module3.Entity.Id,
                        ButtionName = "删除角色",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module3.Entity.Id,
                        ButtionName = "添加模块",
                    });
                    context.T_ModuleButtion.Add(new ModuleButtionEntity
                    {
                        Id = Guid.NewGuid(),
                        ModuleId = module3.Entity.Id,
                        ButtionName = "查看账号层级",
                    });



                    //添加管理员
                    context.T_UserRole.Add(new UserRoleEntity
                    {
                        Id = Guid.NewGuid(),
                        User = user1.Entity,
                        Role = role1.Entity
                    });

                }
                context.SaveChanges();
            }
        }
    }
}
