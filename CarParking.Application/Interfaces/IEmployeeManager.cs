using System.Collections.Generic;
using System.Threading.Tasks;
using CarParking.Application.Models;

namespace CarParking.Application.Interfaces
{
    public interface IEmployeeManager
    {
        Task<bool> Add(EmployeeModel employee);
        Task<IEnumerable<EmployeeModel>> GetAll();
    }
}
