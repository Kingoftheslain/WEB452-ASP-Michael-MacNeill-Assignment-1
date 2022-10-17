using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClocksApp.Models
{
    public class Clocks
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
