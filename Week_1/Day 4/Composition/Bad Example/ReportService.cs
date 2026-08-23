using System;
using System.Collections.Generic;
using System.Text;

namespace Week_1.Day_4.Composition.Bad_Example;

public class ReportService
{
    public void Export(string format, string data)
    {
        if (format == "PDF")
        {
            Console.WriteLine($"Exporting PDF: {data}");
        }
        else if (format == "Excel")
        {
            Console.WriteLine($"Exporting Excel: {data}");
        }
        else if (format == "CSV")
        {
            Console.WriteLine($"Exporting CSV: {data}");
        }
    }
}