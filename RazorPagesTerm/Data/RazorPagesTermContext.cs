using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesTerm.Models
{
    public class RazorPagesTermContext : DbContext
    {
        public RazorPagesTermContext (DbContextOptions<RazorPagesTermContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesTerm.Models.Term> Term { get; set; }
    }
}
   