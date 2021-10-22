using CarParking.Core.Entities;
using CarParking.Core.Repositories;
using CarParking.Infrastructure.Data;
using CarParking.Infrastructure.Repositories.Base;

namespace CarParking.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CarParkingContext dbContext) : base(dbContext)
        {

        }
    }
}
