using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarParking.Application.Interfaces;
using CarParking.Application.Mapper;
using CarParking.Application.Models;
using CarParking.Core.Entities;
using CarParking.Core.Repositories;

namespace CarParking.Application.Business
{
    public class CarManager : ICarManager
    {
        private ICarRepository CarRepository { get; }
        private IEmployeeRepository EmployeeRepository { get; }
        private IParkingAccessCardRepository ParkingAccessCardRepository { get; }

        public CarManager(ICarRepository carRepository, IEmployeeRepository employeeRepository, IParkingAccessCardRepository parkingAccessCardRepository)
        {
            CarRepository = carRepository;
            EmployeeRepository = employeeRepository;
            ParkingAccessCardRepository = parkingAccessCardRepository;
        }

        public async Task<IEnumerable<CarModel>> GetAllCars()
        {
            IReadOnlyList<Car> allCars = await CarRepository.GetAllAsync();
            var allCarModels = ObjectMapper.Mapper.Map<IEnumerable<CarModel>>(allCars);
            return allCarModels;
        }

        public async Task<CarModel> GetById(int carId)
        {
            Car car = await CarRepository.GetByIdAsync(carId);
            CarModel carModel = ObjectMapper.Mapper.Map<CarModel>(car);
            return carModel;
        }

        public async Task<bool> AddCar(CarModel carModel)
        {
            try
            {
                if (!IsCarValidForAdd(carModel))
                {
                    return false;
                }

                Employee employee = await EmployeeRepository.GetByIdAsync(carModel.EmployeeId);
                if (employee == null)
                {
                    return false;
                }

                return await AddCarToEmployee(carModel, employee);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateCar(CarModel carModel)
        {
            var editCar = await CarRepository.GetByIdAsync(carModel.Id);
            if (editCar == null)
            {
                return false;
            }
            ObjectMapper.Mapper.Map(carModel, editCar);
            await CarRepository.UpdateAsync(editCar);
            return true;
        }

        public async Task<bool> Delete(int carId)
        {
            var car = await CarRepository.GetByIdAsync(carId);
            if (car == null)
            {
                return false;
            }
            await CarRepository.DeleteAsync(car);
            return true;
        }

        private bool IsCarValidForAdd(CarModel carModel)
        {
            return carModel.Id == 0 && carModel.EmployeeId > 0;
        }

        private async Task<bool> AddCarToEmployee(CarModel carModel, Employee employee)
        {
            Car car = ObjectMapper.Mapper.Map<Car>(carModel);
            car.Employee = employee;
            car = await CarRepository.AddAsync(car);
            return car?.Id > 0;
        }
    }
}
