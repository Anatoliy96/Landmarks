using LandmarkDAL.Models;
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
            optionsBuilder.UseMySQL("server=localhost;database=Landmarks;user=root;password=root");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }

        internal DbSet<Users> Users { get; set; }

        internal DbSet<Landmark> LandMark { get; set; }

        internal DbSet<Terrain> Terrain { get; set; }
    }
}
