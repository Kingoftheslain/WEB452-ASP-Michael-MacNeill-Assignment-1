using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClocksApp.Models;

namespace ClocksApp.Data
{
    public class ClocksAppContext : DbContext
    {
        public ClocksAppContext(DbContextOptions<ClocksAppContext> options)
            : base(options)
    { 
    }
    
        public DbSet<Clocks> Clocks { get; set; }
    }
}
