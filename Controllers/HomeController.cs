using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ger_Garage.Models;
using Ger_Garage.DataBase;


namespace Ger_Garage.Controllers
{
    public class HomeController : Controller
    {

		private readonly GerGarageDbContext _context;
		public HomeController(GerGarageDbContext context)
		{
			this._context = context;
		}
		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
