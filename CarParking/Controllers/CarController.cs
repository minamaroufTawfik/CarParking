using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarParking.Application.Interfaces;
using CarParking.Application.Models;
using CarParking.Models;

namespace CarParking.Controllers
{
    public class CarController : BootstrapControllerBase
    {
        private ICarManager CarManager { get; }
        private IParkingAccessCardManager ParkingAccessCardManager { get; }

        public CarController(ICarManager carManager, IParkingAccessCardManager parkingAccessCardManager)
        {
            CarManager = carManager;
            ParkingAccessCardManager = parkingAccessCardManager;
        }

        [HttpGet]
        public async Task<JsonActionResult> GetAll()
        {
            try
            {
                var allCars = await CarManager.GetAllCars();
                return JsonUtility.Success(allCars);
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }

        [HttpGet]
        [Route("{carId}")]
        public async Task<JsonActionResult> GetById(int carId)
        {
            try
            {
                var car = await CarManager.GetById(carId);
                return JsonUtility.Success(car, car == null ? "Not Found" : string.Empty);
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }

        [HttpPost]
        public async Task<JsonActionResult> Add(CarModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return JsonUtility.Error(new Exception("Invalid Data"));
                }
                var isSuccess = await CarManager.AddCar(car);
                return isSuccess
                    ? JsonUtility.Success(true)
                    : JsonUtility.Error(new Exception("Failed To Add, You need to send Employee Id"));
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }

        [HttpPost]
        [Route("registerCard/{carId}")]
        public async Task<JsonActionResult> RegisterCard(int carId)
        {
            try
            {
                var isSuccess = await ParkingAccessCardManager.RegisterAccessCard(carId);
                return isSuccess
                    ? JsonUtility.Success(true)
                    : JsonUtility.Error(new Exception("Car Not Found Or Already Registered"));
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }

        [HttpPut]
        public async Task<JsonActionResult> Update(CarModel car)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return JsonUtility.Error(new Exception("Invalid Data"));
                }
                var isSuccess = await CarManager.UpdateCar(car);
                return isSuccess ? JsonUtility.Success(true) : JsonUtility.Error(new Exception("Failed To Update"));
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }

        [HttpPut]
        [Route("pass/{carId}")]
        public async Task<JsonActionResult> PassCar(int carId)
        {
            try
            {
                var result = await ParkingAccessCardManager.PassCar(carId);
                return result.isSuccess
                    ? JsonUtility.Success(result.remaining)
                    : JsonUtility.Error(new Exception("You Need to register card first"));
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }

        [HttpDelete]
        [Route("{carId}")]
        public async Task<JsonActionResult> Delete(int carId)
        {
            try
            {
                var isSuccess = await CarManager.Delete(carId);
                return isSuccess ? JsonUtility.Success(true) : JsonUtility.Error(new Exception("Failed To Delete"));
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }
    }
}
