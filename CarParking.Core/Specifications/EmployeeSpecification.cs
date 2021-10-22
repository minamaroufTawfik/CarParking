using CarParking.Core.Entities;
using CarParking.Core.Specifications.Base;

namespace CarParking.Core.Specifications
{
    public class EmployeeSpecification : BaseSpecification<Employee>
    {
        public EmployeeSpecification(int employeeId) : base(emp => emp.Id == employeeId)
        {
        }
    }
}
