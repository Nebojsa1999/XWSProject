using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PostService.Configuration;

namespace PostService.Models
{
    public class ProjectContext : DbContext
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
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }


            optionsBuilder.UseSqlServer("data source=localhost; Initial Catalog=postXWS;Integrated Security=True;");
        }
    }
}
