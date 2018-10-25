using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BerthApiBeta.Models
{
    public class BerthApiBetaContext : DbContext
    {
        public BerthApiBetaContext (DbContextOptions<BerthApiBetaContext> options)
            : base(options)
        {
        }

        public DbSet<BerthApiBeta.Models.User> User { get; set; }

        public DbSet<BerthApiBeta.Models.Record> Record { get; set; }
    }
}
