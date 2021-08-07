namespace WebApplication8.api.Controllers
{
    public class Company
    {
        public string Name { get; set; }
        public decimal CostPerEmployee { get; set; }
        public decimal CostPerDependent { get; set; }
        public int PaySchedule { get; set; }
        public decimal EmployeeDeduction { get; set; }
        public decimal DefaultEmployeeSalary { get; set; }
    }
}