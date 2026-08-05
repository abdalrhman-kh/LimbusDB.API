using LimbusCharts.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LimbusCharts.API.Data
{
    public class DataDbContext: DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options): base(options)
        {
            
        }

        public DbSet<Identity> Identity { get; set; }
        public DbSet<Sinner> Sinner { get; set; }
        public DbSet<Rarity> Rarity { get; set; }
        public DbSet<IdentityUpTie> IdentityUpTie { get; set; }
        public DbSet<UpTie> UpTie { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<StatusEffect> StatusEffect { get; set; }
        public DbSet<SinAffinity> SinAffinity { get; set; }
        public DbSet<SinAffinityCount> SinAffinityCount { get; set; }
        public DbSet<Passives> Passives { get; set; }
        public DbSet<TraitKeyword> TraitKeyword { get; set; }
        public DbSet<StaggerThreshold> StaggerThreshold { get; set; }
        public DbSet<Season> Season {  get; set; }
        public DbSet<Image> Image { get; set; }

    }
}
