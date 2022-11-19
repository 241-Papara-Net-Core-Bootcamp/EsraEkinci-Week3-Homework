using Microsoft.EntityFrameworkCore;
using Repository.Data.Configurations;
using Repository.Domain;
using Repository.Domain.Entities;
using System;

namespace Repository.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { }

        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            //DbContext'deki tüm table configurationlarını bulup register eder. 
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        
    }
}
