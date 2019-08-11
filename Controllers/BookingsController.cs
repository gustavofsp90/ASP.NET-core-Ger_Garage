using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ger_Garage.DataBase;
using Ger_Garage.Models;
using Microsoft.AspNetCore.Authorization;
using Ger_Garage.Models.Enum;

namespace Ger_Garage.Controllers
{
	[Authorize]

	public class BookingsController : Controller
	{
		private readonly GerGarageDbContext _context;

		public BookingsController(GerGarageDbContext context)
		{
			_context = context;
		}

		// GET: Bookings
		public async Task<IActionResult> Index(DateTime filter)
		{
			List<Booking> bookings = new List<Booking>();
			if (User.Claims.Select(claim => new { claim.Type, claim.Value }).ToArray().Any(x => x.Value == "Administrator"))
			{
				bookings = await _context.Bookings
					.Include(x => x.Customer)
					.Include(x => x.VehicleParts)
					.ThenInclude(x => x.VehiclePart)
					.Include(x => x.StatusBooking)
					.Include(x => x.TypeOfBooking)
					.ToListAsync();
			}
			else
			{
				bookings = await _context.Bookings.Where(x => x.Customer.Email == User.Identity.Name)
					.Include(x => x.Customer)
					.Include(x => x.VehicleParts)
					.ThenInclude(x => x.VehiclePart)
					.Include(x => x.StatusBooking)
					.Include(x => x.TypeOfBooking)
					.ToListAsync();
			}
			if (filter != DateTime.MinValue)
				bookings = bookings.Where(x => x.DateTime.ToShortDateString() == filter.ToShortDateString()).ToList();
			foreach (Booking item in bookings)
			{
				foreach (var cost in item.VehicleParts)
				{
					item.Cost += Convert.ToInt32(cost.VehiclePart.Cost);
				}
				item.Cost += Convert.ToInt32(item.TypeOfBooking.Cost);
			}
			return View(bookings);
		}

		// GET: Bookings/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var booking = await _context.Bookings
				.Include(x => x.Customer)
				.Include(x => x.Vehicle)
				.Include(x => x.VehicleParts)
				.ThenInclude(x => x.VehiclePart)
				.Include(x => x.StatusBooking)
				.Include(x => x.TypeOfBooking)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (booking == null)
			{
				return NotFound();
			}
			foreach (var cost in booking.VehicleParts)
				booking.Cost += Convert.ToInt32(cost.VehiclePart.Cost);
			booking.Cost += Convert.ToInt32(booking.TypeOfBooking.Cost);

			return View(booking);
		}

		// GET: Bookings/Create
		public IActionResult Create(bool dailyLimit = false, bool sunday = false, int selectedVehicleStyle = 0)
		{
			ViewBag.Types = _context.TypeOfBookings.AsEnumerable();
			ViewBag.Status = _context.StatusBookings.AsEnumerable();
			IEnumerable<Vehicle> vehicle = _context.Vehicles.AsEnumerable();
			ViewBag.Vehicles = _context.Vehicles.AsEnumerable();
			if (selectedVehicleStyle > 0)
				ViewBag.Vehicles = _context.Vehicles.Where(x => Convert.ToInt32(x.VehicleStyle) == selectedVehicleStyle).AsEnumerable();
			ViewBag.Mechanics = _context.Mechanics.AsEnumerable();
			ViewBag.VehicleParts = _context.VehicleParts.AsEnumerable();
			ViewBag.Engines = Enum.GetValues(typeof(Engine));
			ViewBag.VehicleStyles = Enum.GetValues(typeof(VehicleStyle));
			ViewBag.IsAdmin = false;
			ViewBag.DailyLimit = dailyLimit;
			ViewBag.Sunday = sunday;
			ViewBag.SelectedVehicleStyle = selectedVehicleStyle;
			return View();
		}

		// POST: Bookings/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,StatusBookingId,VehicleTypeId,TypeOfBookingId,VehicleLicense,VehicleEngine,Comments,DateTime, VehicleStyle, Engine, Cost", "VehicleId", "MechanicsId", "Mechanics", "VehicleParts", "MechanicsIds", "VehiclePartsIds")] Booking booking)
		{
			if (ModelState.IsValid)
			{

				User user = new User();
				user = _context.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault();
				booking.Customer = user;
				//MechanicBooking mb = new MechanicBooking();
				//mb.BookingId = booking.Id;
				//mb.MechanicId = 1;
				//booking.Mechanics = new List<MechanicBooking>();
				//booking.Mechanics.Add(mb);
				booking.StatusBookingId = booking.StatusBookingId == 0 ? 1 : booking.StatusBookingId;

				booking.Mechanics = new List<MechanicBooking>();
				booking.VehicleParts = new List<VehiclePartBooking>();
				if (booking.MechanicsIds != null)
				{
					foreach (int mechanicId in booking.MechanicsIds)
					{
						booking.Mechanics.Add(new MechanicBooking() { MechanicId = mechanicId });
					}
				}
				if (booking.VehiclePartsIds != null)
				{
					foreach (int vehiclePartId in booking.VehiclePartsIds)
					{
						booking.VehicleParts.Add(new VehiclePartBooking() { VehiclePartId = vehiclePartId });
					}
				}

				if (OverDailyLimit(booking.DateTime))
					return RedirectToAction(nameof(Create), new { dailyLimit = true });
				else if (IsSunday(booking.DateTime))
				{
					return RedirectToAction(nameof(Create), new { sunday = true });
				}
				else
				{
					_context.Add(booking);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
			}
			return RedirectToAction(nameof(Index));
		}

		private bool OverDailyLimit(DateTime date)
		{
			int totalBooking = _context.Bookings.Count(x => x.DateTime.ToString("yyyyMMdd") == date.ToString("yyyyMMdd"));
			return totalBooking >= 4;
		}

		private bool IsSunday(DateTime date)
		{
			return date.DayOfWeek == DayOfWeek.Sunday;
		}

		// GET: Bookings/Edit/5
		public async Task<IActionResult> Edit(int? id, bool dailyLimit = false, bool sunday = false)
		{
			if (id == null)
			{
				return NotFound();
			}

			Booking booking = await _context.Bookings.Include(x => x.Mechanics).Include(x => x.VehicleParts).SingleOrDefaultAsync(y => y.Id == id);
			if (booking.Mechanics != null && booking.Mechanics.Count > 0)
			{
				booking.MechanicsIds = new List<int>();
				foreach (MechanicBooking item in booking.Mechanics)
					booking.MechanicsIds.Add(item.MechanicId);
			}

			if (booking.VehicleParts != null && booking.VehicleParts.Count > 0)
			{
				booking.VehiclePartsIds = new List<int>();
				foreach (VehiclePartBooking item in booking.VehicleParts)
					booking.VehiclePartsIds.Add(item.VehiclePartId);
			}

			if (booking == null)
			{
				return NotFound();
			}
			ViewBag.Types = _context.TypeOfBookings.AsEnumerable();
			ViewBag.Status = _context.StatusBookings.AsEnumerable();
			ViewBag.Vehicles = _context.Vehicles.AsEnumerable();
			ViewBag.Mechanics = _context.Mechanics.AsEnumerable();
			ViewBag.VehicleParts = _context.VehicleParts.AsEnumerable();
			ViewBag.Engines = Enum.GetValues(typeof(Engine));
			ViewBag.VehicleStyles = Enum.GetValues(typeof(VehicleStyle));
			ViewBag.DailyLimit = dailyLimit;
			ViewBag.Sunday = sunday;

			return View(booking);
		}

		// POST: Bookings/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,StatusBookingId,VehicleTypeId,TypeOfBookingId,VehicleLicense,VehicleEngine,Comments,DateTime, VehicleStyle, Engine, Cost", "VehicleId", "Mechanics", "VehicleParts", "VehiclePartsId", "MechanicsIds", "VehiclePartsIds")] Booking booking)
		{
			if (id != booking.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					booking.Mechanics = new List<MechanicBooking>();
					booking.VehicleParts = new List<VehiclePartBooking>();


					CleanOldValues(booking.Id);

					foreach (int mechanicId in booking.MechanicsIds)
					{
						booking.Mechanics.Add(new MechanicBooking() { MechanicId = mechanicId });
					}
					foreach (int vehiclePartId in booking.VehiclePartsIds)
					{
						booking.VehicleParts.Add(new VehiclePartBooking() { VehiclePartId = vehiclePartId});
					}

					if (OverDailyLimit(booking.DateTime))
						return RedirectToAction(nameof(Edit), new { dailyLimit = true });
					else if (IsSunday(booking.DateTime))
					{
						return RedirectToAction(nameof(Edit), new { sunday = true });
					}
					_context.Update(booking);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BookingExists(booking.Id))
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
			return View(booking);
		}

		// GET: Bookings/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var booking = await _context.Bookings
				.FirstOrDefaultAsync(m => m.Id == id);
			if (booking == null)
			{
				return NotFound();
			}

			return View(booking);
		}

		// POST: Bookings/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var booking = await _context.Bookings.FindAsync(id);
			_context.Bookings.Remove(booking);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool BookingExists(int id)
		{
			return _context.Bookings.Any(e => e.Id == id);
		}

		private void CleanOldValues(int bookingId)
		{
			List<MechanicBooking> mb = new List<MechanicBooking>();
			mb = _context.MechanicBookings.Where(x => x.BookingId == bookingId).ToList();
			foreach (var item in mb)
			{
				_context.MechanicBookings.Remove(item);
				_context.SaveChanges();
			}

			List<VehiclePartBooking> vp = new List<VehiclePartBooking>();
			vp = _context.VehiclePartBookings.Where(x => x.BookingId == bookingId).ToList();
			foreach (var item in vp)
			{
				_context.VehiclePartBookings.Remove(item);
				_context.SaveChanges();
			}

		}
	}
}
