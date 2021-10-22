using System;
using System.Threading.Tasks;
using CarParking.Application.Interfaces;
using CarParking.Core.Entities;
using CarParking.Core.Repositories;

namespace CarParking.Application.Business
{
    public class ParkingAccessCardManager: IParkingAccessCardManager
    {
        private ICarRepository CarRepository { get; }
        private IParkingAccessCardRepository ParkingAccessCardRepository { get; }
        private ICarAccessHistoryRepository CarAccessHistoryRepository { get; }

        public ParkingAccessCardManager(IParkingAccessCardRepository parkingAccessCardRepository,
            ICarAccessHistoryRepository carAccessHistoryRepository, ICarRepository carRepository)
        {
            ParkingAccessCardRepository = parkingAccessCardRepository;
            CarAccessHistoryRepository = carAccessHistoryRepository;
            CarRepository = carRepository;
        }

        public async Task<bool> RegisterAccessCard(int carId)
        {
            Car car = await CarRepository.GetByIdAsync(carId);
            if (car == null)
            {
                return false;
            }
            const decimal welcomeCredit = 10;
            ParkingAccessCard parkingAccessCard = new ParkingAccessCard
            {
                Balance = welcomeCredit,
                Car = car
            };
            parkingAccessCard = await ParkingAccessCardRepository.AddAsync(parkingAccessCard);
            return parkingAccessCard?.Id > 0;
        }

        public async Task<(decimal remaining, bool isSuccess)> PassCar(int carId)
        {
            ParkingAccessCard parkingAccessCard = await ParkingAccessCardRepository.GetAccessCardByCarId(carId);
            if (parkingAccessCard == null)
            {
                return (0, false);
            }
            CarAccessHistory lasAccessHistory = await CarAccessHistoryRepository.GetLastHistoryForCar(carId);
            if (IsNeedChargeCar(lasAccessHistory))
            {
                const decimal passCost = 4;
                await AddCarAccessHistory(carId, passCost);
                // Todo: Add validation on balance to not charge if will be less than 0
                parkingAccessCard.Balance -= passCost;
                await ParkingAccessCardRepository.UpdateAsync(parkingAccessCard);
            }

            return (parkingAccessCard.Balance, true);
        }

        private bool IsNeedChargeCar(CarAccessHistory lasAccessHistory)
        {
            return lasAccessHistory == null || lasAccessHistory.CreatedOn < DateTime.Now.AddMinutes(-1);
        }

        private Task<CarAccessHistory> AddCarAccessHistory(int carId, decimal cost)
        {
            CarAccessHistory carAccessHistory = new CarAccessHistory
            {
                CarId = carId,
                Cost = cost
            };
            return CarAccessHistoryRepository.AddAsync(carAccessHistory);
        }
    }
}
