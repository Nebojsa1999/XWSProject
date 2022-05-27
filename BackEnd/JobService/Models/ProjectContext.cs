using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobService.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JobService.Models
{
    public class ProjectContext: DbContext
    {
        public static ProjectConfiguration Configuration;

        public ProjectContext(DbContextOptions<ProjectContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                Configuration = configuration;
            }
        }

        public ProjectContext()
        {
        }

        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entires = ChangeTracker.
                Entries().
                Where(e => e.Entity is Entity &&
                (e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (EntityEntry entityEntry in entires)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).Deleted = false;


                }
            }

            return base.SaveChanges();
        }


        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }


            optionsBuilder.UseSqlServer("Server=mssql;Database=jobs;User Id=sa;Password=Your_password123;");
           // optionsBuilder.UseSqlServer("data source=localhost; Initial Catalog=jobxws;Integrated Security=True;");

        }
    }
}
