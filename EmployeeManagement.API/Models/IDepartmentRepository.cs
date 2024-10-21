using EmploymentManagement.Models;

namespace EmployeeManagement.API.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartmentsById(int departmentId);
    }
}
