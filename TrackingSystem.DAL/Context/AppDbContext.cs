using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrackingSystem.DAL.Models;

namespace TrackingSystem.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectTask> ProjectTasks{get;set;}

       public AppDbContext(DbContextOptions<AppDbContext> dbContext):base(dbContext)
        {

        }
    }
}
