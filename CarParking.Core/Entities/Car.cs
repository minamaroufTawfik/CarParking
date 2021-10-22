using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarParking.Core.Entities.Base;

namespace CarParking.Core.Entities
{
    public class Car : Entity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))] 
        public virtual Employee Employee { get; set; }
    }
}
