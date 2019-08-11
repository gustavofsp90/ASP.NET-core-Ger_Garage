﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Ger_Garage.DataBase.GerGarageDbContext _context;

        public DetailsModel(Ger_Garage.DataBase.GerGarageDbContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
