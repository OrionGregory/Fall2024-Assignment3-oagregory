using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassDemo.Models;

namespace ClassDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSets for Movie, Actor, and MovieActor
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<MovieActor> MovieActors { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure unique MovieId and ActorId pairs in MovieActor
            modelBuilder.Entity<MovieActor>()
                .HasIndex(ma => new { ma.MovieId, ma.ActorId })
                .IsUnique();
        }
    }
}
