using EmploymentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentsById(int departmentId)
        {
            return await _context.Departments.FirstOrDefaultAsync(e => e.DepartmentId == departmentId);
        }
    }
}
