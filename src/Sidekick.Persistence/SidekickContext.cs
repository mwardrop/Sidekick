using Microsoft.EntityFrameworkCore;
using Sidekick.Domain.Apis.PoeNinja.Models;
using Sidekick.Domain.Game.Leagues;
using Sidekick.Domain.Views;
using Sidekick.Persistence.Apis.PoeNinja;
using Sidekick.Persistence.Cache;
using Sidekick.Persistence.ItemCategories;
using Sidekick.Persistence.Leagues;
using Sidekick.Persistence.Views;

namespace Sidekick.Persistence
{
    public class SidekickContext : DbContext
    {
        public SidekickContext(DbContextOptions<SidekickContext> options)
            : base(options)
        {
        }

        public DbSet<Cache.Cache> Caches { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<NinjaPrice> NinjaPrices { get; set; }

        public DbSet<NinjaTranslation> NinjaTranslations { get; set; }

        public DbSet<ViewPreference> ViewPreferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("sidekick");
            modelBuilder.ApplyConfiguration(new CacheConfiguration());
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new NinjaPriceConfiguration());
            modelBuilder.ApplyConfiguration(new NinjaTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ViewPreferenceConfiguration());
        }
    }
}
