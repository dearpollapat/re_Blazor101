using EmployeeManagement.Web.Services;
using EmploymentManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        public string ButtonText { get; set; } = "Hide Footer";
        public string CssClass { get; set; } = null;
        public string Coordenates { get; set; }
        public Employee Employee { get; set; } = new Employee();
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Parameter]
        public string Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
        protected void Button_Click()
        {
            if(ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }

        //protected void Mouse_Move(MouseEventArgs e)
        //{
        //    Coordenates = $"X = {e.ClientX} Y = {e.ClientY}";
        //}
    }
}
