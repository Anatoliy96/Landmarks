
using LandmarkDAL.Models;
using LandmarkDAL.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LandmarkDAL.DAO.Context
{
    public class LandmarkContext : DbContext
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

        public DbSet<Landmark> LandMark { get; set; }

        internal DbSet<Terrain> Terrain { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<RegisterTokens> Tokens { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRoleMapping> Mappings { get; set; }
    }
}
