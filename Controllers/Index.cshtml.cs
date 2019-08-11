using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ger_Garage.DataBase;
using Ger_Garage.Models;

namespace Ger_Garage.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly Ger_Garage.DataBase.GerGarageDbContext _context;

        public IndexModel(Ger_Garage.DataBase.GerGarageDbContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; }

        public async Task OnGetAsync()
        {
            Booking = await _context.Bookings.ToListAsync();
        }
    }
}
