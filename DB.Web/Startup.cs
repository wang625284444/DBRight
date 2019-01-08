using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DB.Entity;
using DB.Web.Autofac;
using DB.Web.InitializationData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DB.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        //数据初始化
        public bool SeedType = true;

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //MYsql引用
            //DB.Entity nuget Pomelo.EntityFrameworkCore.MySql
            //services.AddDbContext<BaseDbContext>(options => options.UseMySql(Configuration.GetConnectionString("MySql"),b => { b.MigrationsAssembly("MYSQL"); }));

            //初始化数据库
            //DB.Entity nuget Microsoft.EntityFrameworkCore.SqlServer
            //2012版本
            //services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Datadbec")));
            //2005-2008R2版本
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Datadbec"), b => b.UseRowNumberForPaging()));

            //注册Redis

            //注册MVC路由
            services.AddMvc();

            //注入HttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //注册Session
            services.AddDistributedMemoryCache();
            services.AddSession(c => { c.IdleTimeout = TimeSpan.FromMinutes(60); });

            //注册Cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            //注册配置文件
            services.AddOptions();
            //注册AutoFac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<RegestAutoFac>();
            containerBuilder.Populate(services);
            return containerBuilder.Build().Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //添加初始化数据
            if (SeedType == true)
            {
                SeedData.Seed(app);
            }

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //app.UseAuthentication();    //启用Cook的中间件
            app.UseStaticFiles();   //启用使用静态文件来自本系统的(Jquery和bootstrap等的设置)
            app.UseSession();   //启用Session
            //手动设置MVC路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areaRoute",
                   template: "{area:exists}/{controller=Signin}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Signin}/{action=Index}/{id?}");
            });
        }
    }
}
