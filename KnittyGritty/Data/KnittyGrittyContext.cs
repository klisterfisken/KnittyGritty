using Microsoft.EntityFrameworkCore;
using KnittyGritty.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace KnittyGritty.Data
{
    public class KnittyGrittyContext : IdentityDbContext<IdentityUser>
    {
        public KnittyGrittyContext (DbContextOptions<KnittyGrittyContext> options)
            : base(options)
        {
        }

    public DbSet<Pattern> Pattern { get; set; } = default!;
    public DbSet<Yarn> Yarn { get; set; } = default!;
    public DbSet<Designer> Designer { get; set; } = default!;
    public DbSet<YarnBrand> YarnBrand { get; set; } = default!;
    public DbSet<Size> Size { get; set; } = default!;
    public DbSet<Language> Language { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;

    // Junction tables
    public DbSet<PatternCategory> PatternCategory { get; set; } = default!;
    public DbSet<PatternLanguage> PatternLanguage { get; set; } = default!;
    public DbSet<PatternYarn> PatternYarn { get; set; } = default!;
    public DbSet<PatternSize> PatternSize { get; set; } = default!;
    public DbSet<PatternSizeYarn> PatternSizeYarn { get; set; } = default!;

    // Override
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PatternCategory>()
        .HasKey(pc => new { pc.PatternID, pc.CategoryID });

        modelBuilder.Entity<PatternLanguage>()
        .HasKey(pl => new { pl.PatternID, pl.LanguageID });

        modelBuilder.Entity<PatternSize>()
        .HasKey(ps => new { ps.PatternID, ps.SizeID });

        modelBuilder.Entity<Size>()
        .Property(s => s.SortOrder)
        .HasColumnType("decimal(6, 2)");
        }
    }
}
