using EmploymentManagement.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _httpClient.GetFromJsonAsync<Employee>($"api/Employee/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //try
            //{
            //    var response = await _httpClient.GetAsync("api/Employee");

            //    // Check if request was successful
            //    response.EnsureSuccessStatusCode();

            //    // For debugging - print raw response
            //    var content = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine($"Raw API Response: {content}");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        return await response.Content.ReadFromJsonAsync<Employee[]>();
            //    }

            //    return Array.Empty<Employee>();
            //}
            //catch (Exception ex)
            //{
            //    // Log the error
            //    Console.WriteLine($"Error fetching employees: {ex.Message}");
            //    throw;
            //}
            return await _httpClient.GetFromJsonAsync<Employee[]>("api/Employee");
        }
    }
}
