using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DccyOrigination.EF;
using DccyOrigination.Models.SysManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DccyOrigination
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            //数据库连接
            var conStr = Configuration.GetConnectionString("MySqlConnection");
            services.AddDbContext<DccyDbContext>(options => options.UseSqlServer(conStr));

            //配置文件类与实体类相关联 =》注入
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            //注入session必指定过期时间，httPonly=true 防止oxx攻击
            int dieouttime = Configuration.GetSection("AppSettings:SessionState").GetValue<int>("IdleTimeout");
            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromSeconds(dieouttime); options.Cookie.HttpOnly = true; });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                 name: "API",
                 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
