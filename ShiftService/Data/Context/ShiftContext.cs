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

    }
}
