using System.ComponentModel.DataAnnotations.Schema;
using CarParking.Core.Entities.Base;

namespace CarParking.Core.Entities
{
    public class ParkingAccessCard : Entity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        public virtual Car Car { get; set; }
    }
}
