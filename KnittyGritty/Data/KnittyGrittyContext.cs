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

        public DbSet<KnittyGritty.Models.Designer> Designer { get; set; } = default!;
        public DbSet<KnittyGritty.Models.YarnBrand> YarnBrand { get; set; } = default!;
    }
}
