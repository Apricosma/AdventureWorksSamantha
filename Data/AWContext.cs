using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdventureWorksSamantha.Models;

namespace AdventureWorksSamantha.Data
{
    public class AWContext : DbContext
    {
        public AWContext (DbContextOptions<AWContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Address> Address { get; set; } = default!;
    }
}
