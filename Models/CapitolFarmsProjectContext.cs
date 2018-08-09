using Microsoft.EntityFrameworkCore;

namespace CapitolFarmsProject.Models
{
    public class CapitolFarmsProjectContext : DbContext
    {
        public CapitolFarmsProjectContext (DbContextOptions<CapitolFarmsProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CapitolFarmsProject.Models.Horse> Horse { get; set; }
        public DbSet<CapitolFarmsProject.Models.Grain> Grain { get; set; }
        public DbSet<CapitolFarmsProject.Models.HorseGrain> HorseGrain { get; set; }

    }
}