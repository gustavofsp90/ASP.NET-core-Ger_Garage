using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ger_Garage.Models
{
    public class VehiclePart
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Part { get; set; }
        [DataType(DataType.Currency)]
        public string Cost { get; set; }
    }
}
