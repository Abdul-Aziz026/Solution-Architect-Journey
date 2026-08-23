namespace Week_1.Day_4.Composition.Good_Example;

public class ReportService
{
    private readonly IReportExporter _reportExporter;
    public ReportService(IReportExporter reportExporter)
    {
        _reportExporter = reportExporter;
    }
    public void Export(string data)
    {
        _reportExporter.Export(data);
    }
}


public interface IReportExporter
{
    void Export(string data);
}

public class PdfReportExporter : IReportExporter
{
    public void Export(string data)
    {
        Console.WriteLine($"Exporting PDF: {data}");
    }
}

public class ExcelReportExporter : IReportExporter
{
    public void Export(string data)
    {
        Console.WriteLine($"Exporting Excel: {data}");
    }
}

public class CsvReportExporter : IReportExporter
{
    public void Export(string data)
    {
        Console.WriteLine($"Exporting CSV: {data}");
    }
}

public class JsonReportExporter : IReportExporter
{
    public void Export(string data)
    {
        Console.WriteLine($"Exporting JSON: {data}");
    }
}