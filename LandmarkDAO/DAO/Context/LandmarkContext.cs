
using LandmarkDAL.Models;
using LandmarkDAL.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandmarkDAL.DAO.Context
{
    public class LandmarkContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public LandmarkContext(DbContextOptions<LandmarkContext> options)
           : base(options)
        {
        }

        public LandmarkContext()
            : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=Landmarks;user=root;password=root", b => b.MigrationsAssembly("LandmarksPresentation"));
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }

        internal DbSet<Landmark> LandMark { get; set; }

        internal DbSet<Terrain> Terrain { get; set; }
    }
}
