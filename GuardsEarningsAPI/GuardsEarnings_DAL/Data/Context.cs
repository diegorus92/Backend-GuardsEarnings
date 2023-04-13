using GuardsEarnings_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardsEarnings_DAL.Data
{
    public partial class Context:DbContext
    {
        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) 
        { 
        
        }

        public virtual DbSet<Guard> Guards { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guard>().
                HasMany<Work>(guard => guard.Works).
                WithMany(work => work.Guards);

            modelBuilder.Entity<Target>().
                HasMany<Work>(target => target.Works).
                WithMany(work => work.Targets);

            modelBuilder.Entity<Journey>().
                HasMany<Work>(journey => journey.Works).
                WithMany(work => work.Journeys);
        }
    }
}
