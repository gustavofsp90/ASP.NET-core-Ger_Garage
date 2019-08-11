using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ger_Garage.DataBase;
using Ger_Garage.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Ger_Garage.Controllers
{
	public class UsersController : Controller
	{
		private readonly GerGarageDbContext _context;

		public UsersController(GerGarageDbContext context)
		{
			_context = context;
		}

		// GET: Users
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Index()
		{
			return View(await _context.Users.ToListAsync());
		}

		// GET: Users/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = await _context.Users
				.FirstOrDefaultAsync(m => m.Id == id);
			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		// GET: Users/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Users/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,ConfirmPassword,MobilePhone")] User user)
		{
			if (ModelState.IsValid)
			{
				user.Level = Models.Enum.UserLevel.Normal;
				_context.Add(user);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(user);
		}

		// GET: Users/Edit/5
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			return View(user);
		}

		// POST: Users/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,ConfirmPassword,MobilePhone")] User user)
		{
			if (id != user.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					user.Level = Models.Enum.UserLevel.Normal;
					_context.Update(user);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}
				return RedirectToAction(nameof(Index));
			}
			return View(user);
		}

		// GET: Users/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = await _context.Users
				.FirstOrDefaultAsync(m => m.Id == id);
			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		// POST: Users/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var user = await _context.Users.FindAsync(id);
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool UserExists(string email, string password)
		{
			return _context.Users.Any(e => e.Email == email && e.Password == password);
		}

		[HttpPost]
		public async Task<IActionResult> LoginUser([Bind("Email, Password, RememberMe")] User user)
		{
			if (UserExists(user.Email, user.Password))
			{
				user = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();

				var claims = new List<Claim>{
					new Claim(ClaimTypes.Name, user.Email),
					new Claim("Name", user.Name),
					};
				if (user.Level == Models.Enum.UserLevel.Administrator)
					claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

				var authProperties = new AuthenticationProperties
				{
					//AllowRefresh = <bool>,
					// Refreshing the authentication session should be allowed.

					//ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
					// The time at which the authentication ticket expires. A 
					// value set here overrides the ExpireTimeSpan option of 
					// CookieAuthenticationOptions set with AddCookie.

					IsPersistent = user.RememberMe,
					// Whether the authentication session is persisted across 
					// multiple requests. When used with cookies, controls
					// whether the cookie's lifetime is absolute (matching the
					// lifetime of the authentication ticket) or session-based.

					//IssuedUtc = <DateTimeOffset>,
					// The time at which the authentication ticket was issued.

					//RedirectUri = <string>
					// The full path or absolute URI to be used as an http 
					// redirect response value.
				};
				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity),
					authProperties);



				//var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
				//identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Email));
				//identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
				//// You can add roles to use role-based authorization
				//if (user.Level == Models.Enum.UserLevel.Administrator)
				//{
				//	identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
				//}
				//// Authenticate using the identity
				//var principal = new ClaimsPrincipal(identity);
				//await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = user.RememberMe });
				return RedirectToAction("Index", "Bookings");
			}
			else
			{
				ViewBag.IsInvalid = true;
				return RedirectToAction(nameof(Login), new { isInvalid = true });
			}
		}

		public IActionResult Login(bool isInvalid = false)
		{
			ViewBag.IsInvalid = isInvalid;
			return View();
		}

		public IActionResult AccessDenied()
		{
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Users");
		}
	}
}
