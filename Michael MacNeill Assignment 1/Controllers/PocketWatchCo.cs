using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace Michael_MacNeill_Assignment_1.Controllers
{
    public class PocketWatchCo : Controller
    {
        // GET: /PocketWatchCo/
        public IActionResult Index()
        {
            return View();
        }

    }
}
