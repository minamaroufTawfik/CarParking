using CarParking.Core.Entities;
using CarParking.Core.Repositories;
using CarParking.Infrastructure.Data;
using CarParking.Infrastructure.Repositories.Base;

namespace CarParking.Infrastructure.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(CarParkingContext dbContext): base(dbContext)
        {
            
        }
    }
}
