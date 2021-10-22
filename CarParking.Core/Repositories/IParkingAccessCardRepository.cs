using System.Threading.Tasks;
using CarParking.Core.Entities;
using CarParking.Core.Repositories.Base;

namespace CarParking.Core.Repositories
{
    public interface IParkingAccessCardRepository : IRepository<ParkingAccessCard>
    {
        Task<ParkingAccessCard> GetAccessCardByCarId(int carId);
    }
}
