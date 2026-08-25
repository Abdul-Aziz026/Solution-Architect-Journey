namespace Week_1.Day_6.Coupling.Good_Example;

public class EmployeeManager
{
    public void CreateEmployee()
    {
        Console.WriteLine("Employee created");
    }

    public void UpdateEmployee()
    {
        Console.WriteLine("Employee updated");
    }
}

public class EmailService
{
    public void SendEmail()
    {
        Console.WriteLine("Email sent");
    }
}

public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class SalaryService
{
    public void GenerateSalarySlip()
    {
        Console.WriteLine("Salary slip generated");
    }
}

public class DatabaseBackupService
{
    public void BackupDatabase()
    {
        Console.WriteLine("Database backed up");
    }
}


public class EmployeeService
{
    private readonly EmployeeManager _employeeManager;
    private readonly EmailService _emailService;
    private readonly Logger _logger;
    private readonly SalaryService _salaryService;
    private readonly DatabaseBackupService _databaseBackupService;

    public EmployeeService(EmployeeManager employeeManager, 
        EmailService emailService, 
        Logger logger, 
        SalaryService salaryService, 
        DatabaseBackupService databaseBackupService)
    {
        _employeeManager = employeeManager;
        _emailService = emailService;
        _logger = logger;
        _salaryService = salaryService;
        _databaseBackupService = databaseBackupService;
    }
    public void CreateEmployee()
    {
        _employeeManager.CreateEmployee();
        _logger.Log("Employee created");
        _emailService.SendEmail();
    }
    public void UpdateEmployee()
    {
        _databaseBackupService.BackupDatabase();
        _employeeManager.UpdateEmployee();
        _logger.Log("Employee updated");
        _emailService.SendEmail();
    }

    public void GenerateSalarySlip()
    {
        _salaryService.GenerateSalarySlip();
    }
}