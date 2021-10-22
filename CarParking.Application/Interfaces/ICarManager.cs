
using System.Collections.Generic;
using System.Threading.Tasks;
using CarParking.Application.Models;

namespace CarParking.Application.Interfaces
{
    public interface ICarManager
    {
        Task<IEnumerable<CarModel>> GetAllCars();
        Task<CarModel> GetById(int carId);
        Task<bool> AddCar(CarModel carModel);
        Task<bool> UpdateCar(CarModel carModel);
        Task<bool> Delete(int carId);
    }
}
