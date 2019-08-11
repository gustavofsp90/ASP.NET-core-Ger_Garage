using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ger_Garage.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Ger_Garage.DataBase
{
    public class GerSeeder
    {
        private readonly GerGarageDbContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<User> _userManager;
        public GerSeeder(GerGarageDbContext ctx, IHostingEnvironment hosting, UserManager<User> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }
        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            // Seed the Main User
            User user = await _userManager.FindByEmailAsync("gustavofsp@gergarage.com");
            if (user == null)
            {
                user = new User()
                {
                    Name = "Gustavo",
                    Email = "gustavofsp@gergarage.com",
                    //Username = "gustavofsp90",
                    Password = "P@ssword!",
                    ConfirmPassword = "P@ssw0rd!",
                    MobilePhone = "0838177558",
                    Level = Models.Enum.UserLevel.Administrator
                };


                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }
            }

            

                if (!_ctx.TypeOfBookings.Any())
                {
                    var filepath = Path.Combine(_hosting.ContentRootPath, "DataBase/TypeOfBooking.json");
                    var json = File.ReadAllText(filepath);
                    var typeOfBookings = JsonConvert.DeserializeObject<IEnumerable<TypeOfBooking>>(json);
                    _ctx.TypeOfBookings.AddRange(typeOfBookings);




                    _ctx.SaveChanges();
                }
                if (!_ctx.StatusBookings.Any())
                {
                    var filepath = Path.Combine(_hosting.ContentRootPath, "DataBase/StatusOfBooking.json");
                    var json = File.ReadAllText(filepath);
                    var statusOfBookings = JsonConvert.DeserializeObject<IEnumerable<StatusBooking>>(json);
                    _ctx.StatusBookings.AddRange(statusOfBookings);




                    _ctx.SaveChanges();
                }
              

                if (!_ctx.VehicleTypes.Any())
                {
                    var filepath = Path.Combine(_hosting.ContentRootPath, "DataBase/Vehicles.json");
                    var json = File.ReadAllText(filepath);
                    var vehicles = JsonConvert.DeserializeObject<IEnumerable<VehicleType>>(json);
                    _ctx.VehicleTypes.AddRange(vehicles);




                    _ctx.SaveChanges();
                }
            
        }
    }
}
        

    

