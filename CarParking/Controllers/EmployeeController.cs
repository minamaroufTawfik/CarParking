
using System;
using System.Threading.Tasks;
using CarParking.Application.Interfaces;
using CarParking.Application.Models;
using CarParking.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarParking.Controllers
{
    public class EmployeeController: BootstrapControllerBase
    {
        private IEmployeeManager EmployeeManager { get; }

        public EmployeeController(IEmployeeManager employeeManager)
        {
            EmployeeManager = employeeManager;
        }

        [HttpGet]
        public async Task<JsonActionResult> GetAll()
        {
            try
            {
                var allEmployees = await EmployeeManager.GetAll();
                return JsonUtility.Success(allEmployees);
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }


        [HttpPost]
        public async Task<JsonActionResult> Add(EmployeeModel employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return JsonUtility.Error(new Exception("Invalid Data"));
                }
                var isSuccess = await EmployeeManager.Add(employee);
                return isSuccess
                    ? JsonUtility.Success(true)
                    : JsonUtility.Error(new Exception("Failed To Add"));
            }
            catch (Exception ex)
            {
                return JsonUtility.Error(ex);
            }
        }
    }
}
