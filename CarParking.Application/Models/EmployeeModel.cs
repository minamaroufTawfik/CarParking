using System;
using System.ComponentModel.DataAnnotations;
using CarParking.Application.Models.Base;

namespace CarParking.Application.Models
{
    public class EmployeeModel : BaseModel
    {
        [Required] public string Name { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
