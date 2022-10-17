using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClocksApp.Models
{
    public class Clocks
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "ReleaseDate")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public string Size { get; set; }
    }
}
