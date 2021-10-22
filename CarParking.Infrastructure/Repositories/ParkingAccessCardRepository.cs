using System.Linq;
using System.Threading.Tasks;
using CarParking.Core.Entities;
using CarParking.Core.Repositories;
using CarParking.Infrastructure.Data;
using CarParking.Infrastructure.Repositories.Base;

namespace CarParking.Infrastructure.Repositories
{
    public class ParkingAccessCardRepository: Repository<ParkingAccessCard>, IParkingAccessCardRepository
    {
        public ParkingAccessCardRepository(CarParkingContext dbContext) : base(dbContext)
        {

        }

        public async Task<ParkingAccessCard> GetAccessCardByCarId(int carId)
        {
            ParkingAccessCard parkingAccessCard = (await GetAsync(card => card.CarId == carId)).FirstOrDefault();
            return parkingAccessCard;
        }
    }
}
