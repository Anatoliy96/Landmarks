using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using LandMarkBLL;
using LandmarkDAL.Models.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Landmarks
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
            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie";
                     config.LoginPath = "/Account/Login";
                 });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<LandmarkDAL.DAO.Context.LandmarkContext>(options => {
                options.UseMySQL("Server=127.0.0.1;Database=landmarks;Uid=root;Pwd=root");
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
        //    var builder = new ConfigurationBuilder()
        //.AddJsonFile("appsettings.json");
        //    var config = builder.Build();

        //    var smtpClient = new SmtpClient(config["Smtp:Host"])
        //    {
        //        Port = int.Parse(config["Smtp:Port"]),
        //        Credentials = new NetworkCredential(config["Smtp:Username"], config["Smtp:Password"]),
        //        EnableSsl = true,
        //    };
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
