using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KnittyGritty.Models;

namespace KnittyGritty.Data
{
    public class KnittyGrittyContext : DbContext
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
        modelBuilder.Entity<PatternCategory>()
        .HasKey(pc => new { pc.PatternID, pc.CategoryID });

        modelBuilder.Entity<PatternLanguage>()
        .HasKey(pl => new { pl.PatternID, pl.LanguageID });

        modelBuilder.Entity<PatternYarn>()
        .HasKey(py => new { py.PatternID, py.YarnID });

        modelBuilder.Entity<PatternSize>()
        .HasKey(ps => new { ps.PatternID, ps.SizeID });

        modelBuilder.Entity<PatternSizeYarn>()
        .HasKey(psy => new { psy.PatternID, psy.SizeID, psy.YarnID });
    }
    }
}
