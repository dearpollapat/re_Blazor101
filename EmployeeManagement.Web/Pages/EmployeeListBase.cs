using EmploymentManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees() 
        {
            System.Threading.Thread.Sleep(3000);
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1982,9,23),
                Gender = Gender.Female,
                DepartmentId = 1,
                PhotoPath = "images/1.png"
            };
            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sara2",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/1.png"
            };
            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Sara3",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/1.png"
            };
            Employee e4 = new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara4",
                LastName = "Longway",
                Email = "sara@gmail.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 4,
                PhotoPath = "images/1.png"
            };

            Employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }
}
