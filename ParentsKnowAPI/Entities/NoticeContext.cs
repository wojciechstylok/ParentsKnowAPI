using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentsKnowAPI.Entities
{
    public class NoticeContext : DbContext
    {
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }

        string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=ParentsKnowDb;Trusted_Connection=True;";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notice>()
                .HasOne(u => u.PostedBy)
                .WithMany(n => n.PostedNotices);

            modelBuilder.Entity<Notice>()
                .HasOne(n => n.Group)
                .WithMany(g => g.Notices);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
