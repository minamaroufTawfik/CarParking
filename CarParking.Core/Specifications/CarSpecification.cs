using CarParking.Core.Entities;
using CarParking.Core.Specifications.Base;

namespace CarParking.Core.Specifications
{
    public class CarSpecification : BaseSpecification<Car>
    {
        public CarSpecification(int carId) : base(c => c.Id == carId)
        {
        }
    }
}
