using System.Threading.Tasks;
using CarParking.Core.Entities;
using CarParking.Core.Repositories.Base;

namespace CarParking.Core.Repositories
{
    public interface ICarAccessHistoryRepository:IRepository<CarAccessHistory>
    {
        Task<CarAccessHistory> GetLastHistoryForCar(int carId);
    }
}
