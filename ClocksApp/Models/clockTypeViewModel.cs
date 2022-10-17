using ClocksApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ClocksApp.Controllers
{
    internal class ClockTypeViewModel
    {
        public List<Clocks> Clocks { get; set; }
        public SelectList Type { get; set; }
        public string ClockType { get; set; }
        public string SearchString { get; set; }
        
    }
}