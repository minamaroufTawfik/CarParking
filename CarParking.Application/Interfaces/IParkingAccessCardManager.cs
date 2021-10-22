using System.Threading.Tasks;

namespace CarParking.Application.Interfaces
{
    public interface IParkingAccessCardManager
    {
        Task<bool> RegisterAccessCard(int carId);
        Task<(decimal remaining, bool isSuccess)> PassCar(int carId);
    }
}
