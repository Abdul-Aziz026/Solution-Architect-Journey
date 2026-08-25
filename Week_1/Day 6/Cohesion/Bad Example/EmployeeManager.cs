namespace Week_1.Day_6.Coupling.Bad_Example;

public class EmployeeManager
{
    public void CreateEmployee() {
        Console.WriteLine("Employee created");
    }

    public void UpdateEmployee()
    {
        Console.WriteLine("Employee updated");
    }

    public void SendEmail()
    {
        Console.WriteLine("Email sent");
    }

    public void GenerateSalarySlip()
    {
        Console.WriteLine("Salary slip generated");
    }

    public void BackupDatabase()
    {
        Console.WriteLine("Database backed up");
    }

    public void LogActivity()
    {
        Console.WriteLine("Activity logged");
    }
}
