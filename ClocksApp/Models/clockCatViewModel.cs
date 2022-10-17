using ClocksApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ClocksApp.Controllers
{
    internal class clockCatViewModel
    {
        public SelectList Type { get; set; }
        public List<Clocks> clocks { get; set; }
    }
}