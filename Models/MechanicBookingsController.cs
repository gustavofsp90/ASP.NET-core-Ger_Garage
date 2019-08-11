using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ger_Garage.Models
{
    public class MechanicBookingsController : Controller
    {
        // GET: MechanicBookings
        public ActionResult Index()
        {
            return View();
        }

        // GET: MechanicBookings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MechanicBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MechanicBookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MechanicBookings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MechanicBookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MechanicBookings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MechanicBookings/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}