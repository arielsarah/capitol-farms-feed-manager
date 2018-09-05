using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CapitolFarmsProject.Models
{
    public class CapitolFarmsProjectContext : IdentityDbContext
    {
        public CapitolFarmsProjectContext (DbContextOptions<CapitolFarmsProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CapitolFarmsProject.Models.Horse> Horse { get; set; }
        public DbSet<CapitolFarmsProject.Models.Grain> Grain { get; set; }
        public DbSet<CapitolFarmsProject.Models.HorseGrain> HorseGrain { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HorseGrain>(entity =>
            {
                entity.HasOne(d => d.Horse)
                    .WithMany(p => p.HorseGrains)
                    .HasForeignKey(d => d.HorseId);
                entity.HasOne(d => d.Grain)
                    .WithMany(p => p.HorseGrains)
                    .HasForeignKey(d => d.GrainId);    
            });
        }
    }
}