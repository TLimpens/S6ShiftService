using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.DataTransfer;
using Common.DataTransfer.Shift;


namespace ShiftService.Context
{
    public class ShiftContext : DbContext
    {
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public ShiftContext(DbContextOptions<ShiftContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {

                entity.HasKey(e => new { e.id, e.shiftId });

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name).HasColumnName("name");

                entity.Property(e => e.shiftId).HasColumnName("shiftId");

            });

        }


    }
}
