using System;
using System.ComponentModel.DataAnnotations;
using CarParking.Application.Models.Base;

namespace CarParking.Application.Models
{
    public class CarModel : BaseModel
    {
        [Required]
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int EmployeeId { get; set; }
    }
}
