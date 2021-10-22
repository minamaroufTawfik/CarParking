using System.Collections.Generic;
using System.Threading.Tasks;
using CarParking.Application.Interfaces;
using CarParking.Application.Mapper;
using CarParking.Application.Models;
using CarParking.Core.Entities;
using CarParking.Core.Repositories;

namespace CarParking.Application.Business
{
    public class EmployeeManager : IEmployeeManager
    {
        private IEmployeeRepository EmployeeRepository { get; }

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public async Task<bool> Add(EmployeeModel employeeModel)
        {
            if (employeeModel.Id > 0)
            {
                return false;
            }
            Employee employee = ObjectMapper.Mapper.Map<Employee>(employeeModel);
            employee = await EmployeeRepository.AddAsync(employee);
            return employee?.Id > 0;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            IEnumerable<Employee> allEmployees = await EmployeeRepository.GetAllAsync();
            var allEmployeeModels = ObjectMapper.Mapper.Map<IEnumerable<EmployeeModel>>(allEmployees);
            return allEmployeeModels;
        }
    }
}
