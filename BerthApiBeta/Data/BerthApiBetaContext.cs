using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BerthApiBeta.Models;

namespace BerthApiBeta.Models
{
    public class BerthApiBetaContext : DbContext
    {
        public BerthApiBetaContext (DbContextOptions<BerthApiBetaContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>()
                .Property(b => b.RecordTime)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RaspberryRecord>()
                .Property(c => c.DateTime)
                .HasDefaultValueSql("getdate()");
        }

        public DbSet<BerthApiBeta.Models.User> User { get; set; }

        public DbSet<BerthApiBeta.Models.Record> Record { get; set; }

        public DbSet<BerthApiBeta.Models.RaspberryRecord> RaspberryRecord { get; set; }
    }
}
