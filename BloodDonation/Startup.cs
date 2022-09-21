using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDonation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BloodDonation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<DB>()
            //    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DB>();
            services.AddDbContextPool<DB>(
                option => option.UseSqlServer(Configuration.GetConnectionString("DonationGroup2021")));
            services.AddControllersWithViews();
            services.AddTransient<BloodGroupInt, SqlBloodDonation>();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "840178259934-460nrmu958ns7dpakfv78vop1noum8nu.apps.googleusercontent.com";
                    options.ClientSecret = "Wvr26p7EQ-y47L1k_eXxNfKr";
                })
                .AddFacebook(options =>
                {
                    options.ClientId = "661041575295664";
                    options.ClientSecret = "1536bf82e55c8535fa2590f1debdcdcd";
                })
                .AddTwitter(twitteroptions =>
                {
                    twitteroptions.ConsumerKey = "1261212406128222208-XAk7IazFZtMh2R85MLCMPQxCWhW0G2";
                    twitteroptions.ConsumerSecret = "RkK2D4XAnJuzQkoIjdipWeWxu3lHoZC4lzsOSdSvPl0fZ";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseCookiePolicy();
            app.UseAuthentication();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
