using BLL;
using DAL.Db;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using UsersRewardsWeb.DAL;

namespace UsersRewardsWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ==================== CONFIGURE SERVICES ====================
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Ñòðîêà ïîäêëþ÷åíèÿ
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var config = configurationBuilder.Build();
            var connectionString = config["ConnectionString"];

            // ========== Ðåãèñòðàöèÿ ñóùåñòâóþùèõ DAO è BLL ==========
            services.AddTransient<IUserBL>(x => new UserBL(new UserDbDAO(connectionString)));
            services.AddTransient<IRewardBL>(x => new RewardBL(new RewardDbDAO(connectionString)));

            // ========== ÐÅÃÈÑÒÐÀÖÈß ÄËß ACCOUNT ==========
            services.AddTransient<IAccountDAO>(x => new AccountDbDAO(connectionString));
            services.AddTransient<IAccountBL, AccountBL>();

            // ========== ÑÅÑÑÈÈ ==========
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // ========== ÄËß ÄÎÑÒÓÏÀ Ê ÑÅÑÑÈÈ Â ÊÎÍÒÐÎËËÅÐÀÕ ==========
            services.AddHttpContextAccessor();
        }

        // ==================== CONFIGURE ====================
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            // ========== ÂÀÆÍÎ: ÑÅÑÑÈÈ ÄÎ UseAuthorization ==========
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}