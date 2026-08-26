namespace Week_2.Day_1.SRP.Bad_Example;

public class EmployeeService
{
    public void AddEmployee(Employee employee)
    {
        // Validate employee data
        // Add employee to the system
    }

    public decimal CalculateSalary(Employee employee)
    {
        // Salary calculation logic
        return employee.BasicSalary + employee.Bonus;
    }

    public void SaveToDatabase(Employee employee)
    {
        // Database persistence logic
    }

    public void SendWelcomeEmail(Employee employee)
    {
        // Email sending logic
    }

    public void GenerateEmployeeReport(Employee employee)
    {
        // Generate PDF/report logic
    }

    public void LogActivity(string message)
    {
        // Logging logic
    }
}

public class Employee
{
    public string Name { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public decimal Bonus { get; set; }
}