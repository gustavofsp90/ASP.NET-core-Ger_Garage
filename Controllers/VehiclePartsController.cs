using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ger_Garage.DataBase;
using Ger_Garage.Models;

namespace Ger_Garage.Controllers
{
    public class VehiclePartsController : Controller
    {
        private readonly GerGarageDbContext _context;

        public VehiclePartsController(GerGarageDbContext context)
        {
            _context = context;
        }

        // GET: VehicleParts
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleParts.ToListAsync());
        }

        // GET: VehicleParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclePart = await _context.VehicleParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiclePart == null)
            {
                return NotFound();
            }

            return View(vehiclePart);
        }

        // GET: VehicleParts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Part,Cost")] VehiclePart vehiclePart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiclePart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiclePart);
        }

        // GET: VehicleParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclePart = await _context.VehicleParts.FindAsync(id);
            if (vehiclePart == null)
            {
                return NotFound();
            }
            return View(vehiclePart);
        }

        // POST: VehicleParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Part,Cost")] VehiclePart vehiclePart)
        {
            if (id != vehiclePart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiclePart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclePartExists(vehiclePart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiclePart);
        }

        // GET: VehicleParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiclePart = await _context.VehicleParts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiclePart == null)
            {
                return NotFound();
            }

            return View(vehiclePart);
        }

        // POST: VehicleParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiclePart = await _context.VehicleParts.FindAsync(id);
            _context.VehicleParts.Remove(vehiclePart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclePartExists(int id)
        {
            return _context.VehicleParts.Any(e => e.Id == id);
        }
    }
}
