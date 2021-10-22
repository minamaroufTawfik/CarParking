using System.Linq;
using System.Threading.Tasks;
using CarParking.Core.Entities;
using CarParking.Core.Repositories;
using CarParking.Core.Specifications;
using CarParking.Infrastructure.Data;
using CarParking.Infrastructure.Repositories.Base;

namespace CarParking.Infrastructure.Repositories
{
    public class CarAccessHistoryRepository : Repository<CarAccessHistory>, ICarAccessHistoryRepository
    {
        public CarAccessHistoryRepository(CarParkingContext dbContext) : base(dbContext)
        {

        }

        public async Task<CarAccessHistory> GetLastHistoryForCar(int carId)
        {
            var spec = new CarLastAccessHistoryForCar(carId);
            var lastAccessHistory = (await GetAsync(spec)).FirstOrDefault();
            return lastAccessHistory;
        }
    }
}
