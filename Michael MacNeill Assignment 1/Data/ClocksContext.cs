using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Michael_MacNeill_Assignment_1.Models;

namespace Michael_MacNeill_Assignment_1.Data
{
    public class ClocksContext : DbContext
    {
        public ClocksContext (DbContextOptions<ClocksContext> options)
            : base(options)
        {
        }

        public DbSet<Michael_MacNeill_Assignment_1.Models.Clock> Clock { get; set; }
    }
}
