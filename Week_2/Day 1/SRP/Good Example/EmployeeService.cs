namespace Week_2.Day_1.SRP.Good_Example;

public class EmployeeService
{
    private readonly EmployeeValidator _validator;
    private readonly SalaryCalculator _salaryCalculator;
    private readonly EmployeeRepository _repository;
    private readonly EmailService _emailService;
    private readonly ActivityLogger _activityLogger;

    public EmployeeService(
        EmployeeValidator validator,
        SalaryCalculator salaryCalculator,
        EmployeeRepository repository,
        EmailService emailService,
        ActivityLogger activityLogger)
    {
        _validator = validator;
        _salaryCalculator = salaryCalculator;
        _repository = repository;
        _emailService = emailService;
        _activityLogger = activityLogger;
    }

    // Responsibility:
    // Coordinate the employee onboarding workflow.
    public void AddEmployee(Employee employee)
    {
        if (!_validator.Validate(employee))
        {
            throw new ArgumentException("Invalid employee data.");
        }

        decimal salary = _salaryCalculator.CalculateSalary(employee);

        _repository.Save(employee, salary);

        _emailService.SendWelcomeEmail(employee);

        _activityLogger.LogActivity(
            $"Employee '{employee.Name}' added to the system.");
    }
}


public class EmployeeValidator
{
    // Responsibility:
    // Validate employee data.
    public bool Validate(Employee employee)
    {
        return !string.IsNullOrWhiteSpace(employee.Name)
               && employee.BasicSalary >= 0
               && employee.Bonus >= 0;
    }
}


public class SalaryCalculator
{
    // Responsibility:
    // Calculate employee salary.
    public decimal CalculateSalary(Employee employee)
    {
        return employee.BasicSalary + employee.Bonus;
    }
}


public class EmployeeRepository
{
    // Responsibility:
    // Persist employee data.
    public void Save(Employee employee, decimal salary)
    {
        Console.WriteLine(
            $"Employee '{employee.Name}' saved with salary {salary}.");
    }
}


public class EmailService
{
    // Responsibility:
    // Handle employee email communication.
    public void SendWelcomeEmail(Employee employee)
    {
        Console.WriteLine(
            $"Welcome email sent to '{employee.Name}'.");
    }
}


public class ActivityLogger
{
    // Responsibility:
    // Record application activity.
    public void LogActivity(string message)
    {
        Console.WriteLine($"LOG: {message}");
    }
}


public class EmployeeReportGenerator
{
    // Responsibility:
    // Generate employee reports.
    public void GenerateEmployeeReport(Employee employee)
    {
        Console.WriteLine(
            $"Report generated for employee '{employee.Name}'.");
    }
}


public class Employee
{
    public string Name { get; set; } = string.Empty;

    public decimal BasicSalary { get; set; }

    public decimal Bonus { get; set; }
}