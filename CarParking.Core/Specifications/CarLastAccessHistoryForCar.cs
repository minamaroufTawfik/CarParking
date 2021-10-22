using CarParking.Core.Entities;
using CarParking.Core.Specifications.Base;

namespace CarParking.Core.Specifications
{
    public class CarLastAccessHistoryForCar : BaseSpecification<CarAccessHistory>
    {
        public CarLastAccessHistoryForCar(int carId) : base(access => access.CarId == carId)
        {
            ApplyOrderByDescending(access => access.CreatedOn);
        }
    }
}
